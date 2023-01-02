using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuppeteerSharp;

namespace PuppeteerSharpDemo
{
    internal class PuppeteerCore
    {
        internal async void Run()
        {
            //DemoRun();

            var options = new LaunchOptions
            {
                Headless = false
            };

            Console.WriteLine("Downloading chromium");
            //初始化PuppeteerSharp的一个新实例。BrowserFetcher类。
            using var browserFetcher = new BrowserFetcher();
            //下载修订版本。解析完成下载的任务。
            await browserFetcher.DownloadAsync();

            Console.WriteLine("Navigating baidu");
            //该方法使用给定的参数启动一个浏览器实例。浏览器将在浏览器被释放时关闭。
            using (var browser = await Puppeteer.LaunchAsync(options))
            //创建新页面
            //任务解析为一个新的PuppeteerSharp。页面对象
            using (var page = await browser.NewPageAsync())
            {
                await page.GoToAsync("https://www.douyin.com/");

                //
            }
        }

        async void DemoRun()
        {
            var options = new LaunchOptions
            {
                Headless = true
            };

            Console.WriteLine("Downloading chromium");
            //初始化PuppeteerSharp的一个新实例。BrowserFetcher类。
            using var browserFetcher = new BrowserFetcher();
            //下载修订版本。解析完成下载的任务。
            await browserFetcher.DownloadAsync();

            Console.WriteLine("Navigating baidu");
            //该方法使用给定的参数启动一个浏览器实例。浏览器将在浏览器被释放时关闭。
            using (var browser = await Puppeteer.LaunchAsync(options))
            //创建新页面
            //任务解析为一个新的PuppeteerSharp。页面对象
            using (var page = await browser.NewPageAsync())
            {
                await page.GoToAsync("http://www.baidu.com");

                Console.WriteLine("Generating PDF");
                await page.PdfAsync(Path.Combine(Directory.GetCurrentDirectory(), "baidu.pdf"));

                Console.WriteLine("Export completed");
            }
        }
    }
}
