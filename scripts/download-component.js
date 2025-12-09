/**
 * Download popular UI components from uiverse-io/galaxy repository
 * uiverse-io/galaxy 저장소에서 인기 UI 컴포넌트를 다운로드합니다.
 */

import fs from 'fs/promises';
import path from 'path';

const GITHUB_API_BASE = 'https://api.github.com/repos/uiverse-io/galaxy/contents';
const RAW_CONTENT_BASE = 'https://raw.githubusercontent.com/uiverse-io/galaxy/main';

// Available categories in the Galaxy repository
// Galaxy 저장소에서 사용 가능한 카테고리
const CATEGORIES = [
    'Buttons',
    'Cards',
    'Checkboxes',
    'Forms',
    'Inputs',
    'loaders',
    'Notifications',
    'Patterns',
    'Radio-buttons',
    'Toggle-switches',
    'Tooltips'
];

/**
 * Get list of files from a GitHub repository directory
 * GitHub 저장소 디렉토리에서 파일 목록을 가져옵니다.
 */
async function getFilesFromCategory(category) {
    const url = `${GITHUB_API_BASE}/${category}`;
    const headers = {
        'Accept': 'application/vnd.github.v3+json',
        'User-Agent': 'uiverse-to-wpf-automation'
    };

    // Add GitHub token if available
    // GitHub 토큰이 있으면 추가합니다.
    if (process.env.GITHUB_TOKEN) {
        headers['Authorization'] = `token ${process.env.GITHUB_TOKEN}`;
    }

    const response = await fetch(url, { headers });

    if (!response.ok) {
        throw new Error(`Failed to fetch ${category}: ${response.status} ${response.statusText}`);
    }

    const files = await response.json();
    return files.filter(f => f.name.endsWith('.html'));
}

/**
 * Download raw file content from GitHub
 * GitHub에서 파일 원본 내용을 다운로드합니다.
 */
async function downloadFile(category, filename) {
    const url = `${RAW_CONTENT_BASE}/${category}/${filename}`;
    const response = await fetch(url, {
        headers: { 'User-Agent': 'uiverse-to-wpf-automation' }
    });

    if (!response.ok) {
        throw new Error(`Failed to download ${filename}: ${response.status}`);
    }

    return response.text();
}

/**
 * Select a random component from a random category
 * 랜덤 카테고리에서 랜덤 컴포넌트를 선택합니다.
 */
async function selectRandomComponent() {
    // Select random category
    // 랜덤 카테고리 선택
    const category = CATEGORIES[Math.floor(Math.random() * CATEGORIES.length)];
    console.log(`Selected category: ${category}`);

    // Get files from category
    // 카테고리에서 파일 목록 가져오기
    const files = await getFilesFromCategory(category);

    if (files.length === 0) {
        throw new Error(`No HTML files found in ${category}`);
    }

    // Select random file
    // 랜덤 파일 선택
    const file = files[Math.floor(Math.random() * files.length)];
    console.log(`Selected component: ${file.name}`);

    return { category, filename: file.name };
}

/**
 * Check if component was already processed
 * 컴포넌트가 이미 처리되었는지 확인합니다.
 */
async function isAlreadyProcessed(componentName, processedLogPath) {
    try {
        const content = await fs.readFile(processedLogPath, 'utf8');
        return content.split('\n').includes(componentName);
    } catch {
        return false;
    }
}

/**
 * Add component to processed log
 * 처리된 컴포넌트 로그에 추가합니다.
 */
async function markAsProcessed(componentName, processedLogPath) {
    await fs.appendFile(processedLogPath, componentName + '\n');
}

/**
 * Generate control name from filename
 * 파일명에서 컨트롤 이름을 생성합니다.
 */
function generateControlName(filename) {
    // Extract meaningful part from filename
    // 파일명에서 의미있는 부분 추출
    // Example: "adamgiebl_big-ape-36.html" -> "BigApe36"
    const baseName = path.basename(filename, '.html');
    const parts = baseName.split('_');
    const namePart = parts.length > 1 ? parts[1] : parts[0];

    // Convert to PascalCase
    // PascalCase로 변환
    return namePart
        .split('-')
        .map(part => part.charAt(0).toUpperCase() + part.slice(1))
        .join('');
}

/**
 * Main execution
 * 메인 실행
 */
async function main() {
    const scriptDir = path.dirname(new URL(import.meta.url).pathname);
    // Handle Windows path
    // Windows 경로 처리
    const normalizedDir = scriptDir.startsWith('/') && process.platform === 'win32'
        ? scriptDir.slice(1)
        : scriptDir;

    const projectRoot = path.resolve(normalizedDir, '..');
    const sourceDir = path.join(projectRoot, 'WebToDesktop', 'source');
    const processedLogPath = path.join(sourceDir, '.processed.log');

    console.log('=== Uiverse.io Component Downloader ===');
    console.log(`Source directory: ${sourceDir}`);

    // Ensure source directory exists
    // 소스 디렉토리 존재 확인
    await fs.mkdir(sourceDir, { recursive: true });

    // Try up to 10 times to find an unprocessed component
    // 처리되지 않은 컴포넌트를 찾기 위해 최대 10번 시도
    let attempts = 0;
    let component = null;

    while (attempts < 10) {
        attempts++;
        const selected = await selectRandomComponent();
        const controlName = generateControlName(selected.filename);

        if (await isAlreadyProcessed(selected.filename, processedLogPath)) {
            console.log(`Component ${selected.filename} already processed, trying another...`);
            continue;
        }

        component = { ...selected, controlName };
        break;
    }

    if (!component) {
        console.error('Could not find an unprocessed component after 10 attempts');
        process.exit(1);
    }

    // Download the component
    // 컴포넌트 다운로드
    console.log(`Downloading ${component.filename}...`);
    const htmlContent = await downloadFile(component.category, component.filename);

    // Create timestamped directory
    // 타임스탬프 디렉토리 생성
    const timestamp = new Date().toISOString().slice(0, 10).replace(/-/g, '');
    const componentDir = path.join(sourceDir, `${timestamp}_${component.controlName}`);
    await fs.mkdir(componentDir, { recursive: true });

    // Save the HTML file
    // HTML 파일 저장
    const htmlPath = path.join(componentDir, `${component.controlName}.html`);
    await fs.writeFile(htmlPath, htmlContent);
    console.log(`Saved: ${htmlPath}`);

    // Save metadata
    // 메타데이터 저장
    const metadata = {
        originalFilename: component.filename,
        category: component.category,
        controlName: component.controlName,
        downloadedAt: new Date().toISOString(),
        sourceUrl: `${RAW_CONTENT_BASE}/${component.category}/${component.filename}`
    };

    const metadataPath = path.join(componentDir, 'metadata.json');
    await fs.writeFile(metadataPath, JSON.stringify(metadata, null, 2));
    console.log(`Saved: ${metadataPath}`);

    // Mark as processed
    // 처리됨으로 표시
    await markAsProcessed(component.filename, processedLogPath);

    // Output for next step
    // 다음 단계를 위한 출력
    console.log('\n=== Download Complete ===');
    console.log(`Control Name: ${component.controlName}`);
    console.log(`HTML Path: ${htmlPath}`);
    console.log(`Category: ${component.category}`);

    // Write output file for GitHub Actions
    // GitHub Actions용 출력 파일 작성
    const outputPath = path.join(sourceDir, 'latest-download.json');
    await fs.writeFile(outputPath, JSON.stringify({
        controlName: component.controlName,
        htmlPath: htmlPath,
        componentDir: componentDir,
        category: component.category
    }, null, 2));

    console.log(`\nOutput written to: ${outputPath}`);
}

main().catch(err => {
    console.error('Error:', err.message);
    process.exit(1);
});
