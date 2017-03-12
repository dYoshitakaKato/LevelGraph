using Grabacr07.KanColleViewer.Composition;
using System;
using System.ComponentModel.Composition;

namespace LevelGraph
{
    [Export(typeof(IPlugin))]
    [ExportMetadata("Title", "LevelGraph")]
    [ExportMetadata("Description", "レベルグラフ")]
    [ExportMetadata("Version", "0.1")]
    [ExportMetadata("Author", "日和")]
    [ExportMetadata("Guid", "39CA5F3B-BE6A-445A-96FD-7ED2E150683E")]
    [Export(typeof(ITool))]
    class Plugin : IPlugin, ITool
    {
        public void Initialize()
        {
                throw new NotImplementedException();
        }

        public string Name => "LevelGraph";

        public object View => new UserControl1();
    }
}