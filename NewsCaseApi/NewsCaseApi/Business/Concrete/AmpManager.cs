using HtmlAgilityPack;
using NewsCaseApi.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsCaseApi.Business.Concrete
{
    public class AmpManager: IAmpService
    {

        public string AmpValidation(string html)
        {
            html = UpdateAmpImages(html);
            html = UpdateAmpIframe(html);
            html = ReplaceWithLink("script", html);
            html = ReplaceWithLink("iframe", html);
            html = ReplaceWithStyle("//*[@style]",html);
            html = ReplaceWithOnclick("//*[@onclick]", html);
            return html;
        }
        private string ReplaceWithOnclick(string tag,string response)
        {
            var doc = GetHtmlDocument(response);
            var elements = doc.DocumentNode.SelectNodes(tag);
            if (elements != null)
            {
                foreach (var htmlNode in elements)
                {
                    if (htmlNode.Attributes["onclick"] == null) continue;

                    htmlNode.Attributes["onclick"].Remove();
                }
                return doc.DocumentNode.InnerHtml;

            }
            return response;
        }
        private string ReplaceWithStyle(string tag, string response)
        {
            var doc = GetHtmlDocument(response);
            var elements = doc.DocumentNode.SelectNodes(tag);
            if (elements!=null)
            {
                foreach (var htmlNode in elements)
                {
                    if (htmlNode.Attributes["style"] == null) continue;

                    htmlNode.Attributes["style"].Remove();
                }
                return doc.DocumentNode.InnerHtml;

            }
            return response;
        }
        private string ReplaceWithLink(string tag, string response)
        {
            var doc = GetHtmlDocument(response);
            var elements = doc.DocumentNode.Descendants(tag);
            foreach (var htmlNode in elements)
            {
                if (htmlNode.Attributes["data-link"] == null) continue;

                var dataLink = htmlNode.Attributes["data-link"].Value;
                var paragraph = doc.CreateElement("p");

                var text = String.Format("[Embedded Link] {0}", dataLink);

                var anchor = doc.CreateElement("a");
                anchor.InnerHtml = text;
                anchor.Attributes.Add("href", dataLink);
                anchor.Attributes.Add("title", text);
                paragraph.InnerHtml = anchor.OuterHtml;

                var original = htmlNode.OuterHtml;
                var replacement = paragraph.OuterHtml;

                response = response.Replace(original, replacement);
            }

            return response;
        }
        private string UpdateAmpImages(string response)
        {
            var doc = GetHtmlDocument(response);
            var imageList = doc.DocumentNode.Descendants("img");

            const string ampImage = "amp-img";

            if (!imageList.Any()) return response;

            if (!HtmlNode.ElementsFlags.ContainsKey("amp-img"))
            {
                HtmlNode.ElementsFlags.Add("amp-img", HtmlElementFlag.Closed);
            }

            foreach (var imgTag in imageList)
            {
                var original = imgTag.OuterHtml;
                var replacement = imgTag.Clone();
                replacement.Name = ampImage;
                replacement.Attributes.Remove("caption");
                if (replacement.Attributes["width"] ==null)
                    replacement.Attributes.Add("width", "1.33");

                if (replacement.Attributes["height"] == null)
                    replacement.Attributes.Add("height", "1");
               

                response = response.Replace(original, replacement.OuterHtml);
            }

            return response;
        }
        private string UpdateAmpIframe(string response)
        {
            var doc = GetHtmlDocument(response);
            var iframeList = doc.DocumentNode.Descendants("iframe");

            const string ampImage = "amp-iframe";

            if (!iframeList.Any()) return response;

            if (!HtmlNode.ElementsFlags.ContainsKey("amp-iframe"))
            {
                HtmlNode.ElementsFlags.Add("amp-iframe", HtmlElementFlag.Closed);
            }

            foreach (var iFrameTag in iframeList)
            {
                var original = iFrameTag.OuterHtml;
                var replacement = iFrameTag.Clone();
                replacement.Name = ampImage;
                //replacement.Attributes.Remove("caption");
                //replacement.Attributes.Remove("width");
                //replacement.Attributes.Remove("height");
                //replacement.Attributes.Add("width", "1");
                //replacement.Attributes.Add("height", "1");

                response = response.Replace(original, replacement.OuterHtml);
            }

            return response;
        }
        private HtmlDocument GetHtmlDocument(string htmlContent)
        {
            var doc = new HtmlDocument
            {
                OptionOutputAsXml = true,
                OptionDefaultStreamEncoding = Encoding.UTF8
            };
            doc.LoadHtml(htmlContent);
            return doc;
        }

    }
}

