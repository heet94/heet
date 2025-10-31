const puppeteer = require('puppeteer');
const path = require('path');
const fs = require('fs');

(async () => {
  try {
    const screenshotsDir = path.resolve(__dirname, 'screenshots');
    if (!fs.existsSync(screenshotsDir)) fs.mkdirSync(screenshotsDir, { recursive: true });

    const browser = await puppeteer.launch({ args: ['--no-sandbox', '--disable-setuid-sandbox'] });
    const page = await browser.newPage();

    // List of local SVG files we created previously
    const files = [
      'home_screenshot.svg',
      'books_index_screenshot.svg'
    ];

    for (const f of files) {
      const filePath = path.join(screenshotsDir, f);
      if (!fs.existsSync(filePath)) {
        console.warn('Missing file:', filePath, '- skipping');
        continue;
      }

      const fileUrl = 'file://' + filePath.replace(/\\/g, '/');
      console.log('Opening', fileUrl);
      await page.setViewport({ width: 1200, height: 800, deviceScaleFactor: 1 });
      await page.goto(fileUrl, { waitUntil: 'networkidle0' });
      const outName = f.replace(/\.svg$/, '.png');
      const outPath = path.join(screenshotsDir, outName);
      await page.screenshot({ path: outPath, fullPage: true });
      console.log('Saved', outPath);
    }

    await browser.close();
    console.log('All done');
  } catch (err) {
    console.error(err);
    process.exit(1);
  }
})();
