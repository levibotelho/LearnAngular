Spoon
---------------------------------------------------------------------------------------------------

To use Spoon, insert the following code into the Application_Start() method in your global.asax.

---

// Dictionary mapping escaped fragments to page URLs. This may be generated from a Sitemap.
var escapedFragmentUrlPairs = new Dictionary<string, string>
{
    { "/home", "http://www.example.com/!#/home" },
    { "/about", "http://www.example.com/!#/about" },
    { "/contact", "http://www.example.com/!#/contact" },
};

var snapshotsPath = HostingEnvironment.MapPath("[Path]");
var snapshotsDirectory = new DirectoryInfo(snapshotsPath);
foreach (var file in snapshotsDirectory.EnumerateFiles())
    file.Delete();
	
SnapshotManager.InitializeAsync(escapedFragmentUrlPairs, snapshotsPath).Wait();

---

To hook Spoon into your site, rewrite your default action method as follows.

---

public async Task<ActionResult> Index(string _escaped_fragment_)
{
    if (_escaped_fragment_ != null)
    {
        string path;
        try
        {
            path = await SnapshotManager.GetSnapshotUrlAsync(_escaped_fragment_);
        }
        catch (ArgumentException)
        {
            // Failure logic here.
        }
        return File(path, "text/html");
    }

    return View();
}

---

Please report any issues or bugs at https://github.com/LeviBotelho/spoon/issues.