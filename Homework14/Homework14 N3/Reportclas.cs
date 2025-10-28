namespace Homework14_N3;

public class Reportclas
{
}
class HtmlHeader { public string GetContent() => "<header> My Header </header>"; }
class HtmlBody { public string GetContent() => "<body>Video provides a powerful way...</body>"; }
class HtmlFooter { public string GetContent() => "<footer> My Footer </footer>"; }
class PdfHeader { public string GetContent() => "Header : I'm using Facade Pattern"; }
class PdfBody { public string GetContent() => "Body : Video provides a powerful way..."; }
class PdfFooter { public string GetContent() => "Footer: Page 1"; }
class ReportFacade
{
    public string GenerateReport(string type)
    {
        if (type.ToUpper() == "HTML")
        {
            return new HtmlHeader().GetContent() + "\n" +
                   new HtmlBody().GetContent() + "\n" +
                   new HtmlFooter().GetContent();
        }
        else if (type.ToUpper() == "PDF")
        {
            return new PdfHeader().GetContent() + "\n" +
                   new PdfBody().GetContent() + "\n" +
                   new PdfFooter().GetContent();
        }
        else
        {
            return "Invalid report type";
        }
    }
}

