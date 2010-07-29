using System.IO;

namespace Spec.Dox.Presentation.Views
{
    public interface IReportPublisher
    {
        void Publish(string expected_html, string test_assembly_path);
    }

    public class ReportPublisher : IReportPublisher
    {
        public void Publish(string html_to_publish, string test_assembly_path)
        {
            var pathToWriteReportTo = Path.Combine(new FileInfo(test_assembly_path).DirectoryName, "report.html");
            File.WriteAllText(pathToWriteReportTo, html_to_publish);
            System.Console.Out.WriteLine("Report published to... {0}", pathToWriteReportTo);
        }
    }
}