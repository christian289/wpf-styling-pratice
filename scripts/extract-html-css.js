/**
 * Extract HTML and CSS from downloaded uiverse.io component
 * 다운로드한 uiverse.io 컴포넌트에서 HTML과 CSS를 분리합니다.
 *
 * uiverse.io components have inline <style> tags, this script separates them
 * uiverse.io 컴포넌트는 인라인 <style> 태그를 가지고 있으며, 이 스크립트로 분리합니다.
 */

import fs from 'fs/promises';
import path from 'path';

/**
 * Parse HTML content and extract CSS from style tags
 * HTML 내용을 파싱하여 style 태그에서 CSS를 추출합니다.
 */
function extractStylesFromHtml(htmlContent) {
    const styles = [];
    const styleRegex = /<style[^>]*>([\s\S]*?)<\/style>/gi;

    let match;
    while ((match = styleRegex.exec(htmlContent)) !== null) {
        styles.push(match[1].trim());
    }

    // Remove style tags from HTML
    // HTML에서 style 태그 제거
    const htmlWithoutStyles = htmlContent.replace(styleRegex, '').trim();

    return {
        css: styles.join('\n\n'),
        html: htmlWithoutStyles
    };
}

/**
 * Clean and format HTML
 * HTML 정리 및 포맷팅
 */
function cleanHtml(html) {
    // Remove excessive whitespace but preserve structure
    // 과도한 공백 제거하되 구조 유지
    return html
        .replace(/^\s*[\r\n]/gm, '') // Remove empty lines
        .replace(/\s+$/gm, '')       // Remove trailing whitespace
        .trim();
}

/**
 * Clean and format CSS
 * CSS 정리 및 포맷팅
 */
function cleanCss(css) {
    return css
        .replace(/^\s*[\r\n]/gm, '')
        .trim();
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

    console.log('=== HTML/CSS Extractor ===');

    // Read latest download info
    // 최신 다운로드 정보 읽기
    const latestDownloadPath = path.join(sourceDir, 'latest-download.json');

    let downloadInfo;
    try {
        const content = await fs.readFile(latestDownloadPath, 'utf8');
        downloadInfo = JSON.parse(content);
    } catch (err) {
        console.error('Could not read latest-download.json. Run download-component.js first.');
        console.error('latest-download.json을 읽을 수 없습니다. 먼저 download-component.js를 실행하세요.');
        process.exit(1);
    }

    console.log(`Processing: ${downloadInfo.controlName}`);
    console.log(`Source: ${downloadInfo.htmlPath}`);

    // Read the original HTML
    // 원본 HTML 읽기
    const originalHtml = await fs.readFile(downloadInfo.htmlPath, 'utf8');

    // Extract CSS and HTML
    // CSS와 HTML 분리
    const { css, html } = extractStylesFromHtml(originalHtml);

    if (!css) {
        console.warn('Warning: No <style> tags found in the HTML file');
        console.warn('경고: HTML 파일에서 <style> 태그를 찾을 수 없습니다.');
    }

    // Clean extracted content
    // 추출된 내용 정리
    const cleanedHtml = cleanHtml(html);
    const cleanedCss = cleanCss(css);

    // Save separated files
    // 분리된 파일 저장
    const componentDir = downloadInfo.componentDir;

    // Save clean HTML (structure only)
    // 깨끗한 HTML 저장 (구조만)
    const cleanHtmlPath = path.join(componentDir, `${downloadInfo.controlName}.structure.html`);
    await fs.writeFile(cleanHtmlPath, cleanedHtml);
    console.log(`Saved HTML structure: ${cleanHtmlPath}`);

    // Save CSS
    // CSS 저장
    const cssPath = path.join(componentDir, `${downloadInfo.controlName}.css`);
    await fs.writeFile(cssPath, cleanedCss);
    console.log(`Saved CSS: ${cssPath}`);

    // Update download info with new paths
    // 새 경로로 다운로드 정보 업데이트
    downloadInfo.structureHtmlPath = cleanHtmlPath;
    downloadInfo.cssPath = cssPath;
    downloadInfo.extractedAt = new Date().toISOString();

    await fs.writeFile(latestDownloadPath, JSON.stringify(downloadInfo, null, 2));

    console.log('\n=== Extraction Complete ===');
    console.log(`Control Name: ${downloadInfo.controlName}`);
    console.log(`HTML (original): ${downloadInfo.htmlPath}`);
    console.log(`HTML (structure): ${cleanHtmlPath}`);
    console.log(`CSS: ${cssPath}`);

    // Summary for Claude Code
    // Claude Code를 위한 요약
    console.log('\n=== For wpf-custom-control command ===');
    console.log(`/wpf-custom-control ${downloadInfo.controlName} "${downloadInfo.htmlPath}" "${cssPath}"`);
}

main().catch(err => {
    console.error('Error:', err.message);
    process.exit(1);
});
