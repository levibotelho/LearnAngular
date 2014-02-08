
namespace AngularTutorial.Web.Models.Home
{
    public class IndexModel
    {
        public IndexModel() { }

        public IndexModel(string[] moduleNames)
        {
            ModuleNames = moduleNames;
        }

        public string[] ModuleNames { get; set; }
    }
}