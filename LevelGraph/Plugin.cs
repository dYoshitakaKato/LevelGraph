using Grabacr07.KanColleViewer.Composition;
using Grabacr07.KanColleWrapper;
using Grabacr07.KanColleWrapper.Models;
using MetroTrilithon.Lifetime;
using MetroTrilithon.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Collections.Generic;
using StatefulModel;
using System.Data.Entity.Core.Objects;

namespace LevelGraph
{
    [Export(typeof(IPlugin))]
    [ExportMetadata("Title", "LevelGraph")]
    [ExportMetadata("Description", "レベルグラフ")]
    [ExportMetadata("Version", "0.1")]
    [ExportMetadata("Author", "日和")]
    [ExportMetadata("Guid", "39CA5F3B-BE6A-445A-96FD-7ED2E150683E")]
    [Export(typeof(ITool))]
    class Plugin : IPlugin, ITool, IDisposableHolder
    {
        private bool initialized;

        private readonly MultipleDisposable compositDisposable = new MultipleDisposable();
        private readonly List<IDisposable> fleetHandlers = new List<IDisposable>();

        public void Initialize()
        {
            KanColleClient.Current
                .Subscribe(nameof(KanColleClient.IsStarted), () => this.InitializeCore(), false)
                .AddTo(this);
        }

        public void InitializeCore()
        {
            var homeport = KanColleClient.Current.Homeport;
            if (homeport == null) return;
            this.initialized = true;
            homeport.Organization
                .Subscribe(nameof(Organization.Fleets), this.test)
                .AddTo(this);
        }

        public void test()
        {
            if (!this.initialized) return;

            /*
            foreach (var handler in this.fleetHandlers)
            {
                handler.Dispose();
            }
            this.fleetHandlers.Clear();
            */

            if (!KanmusuDbUtil.checKanmusuLevelTable())
            {
                KanmusuDbUtil.createKanmusuLevelTable();
                foreach (var test in KanColleClient.Current.Homeport.Organization.Fleets.Values)
                {
                    this.fleetHandlers.Add(test.Subscribe(nameof(Fleet.Ships), KanmusuDbUtil.insertKanmusuLevel));
                }
            }
        }

        public void Dispose() => this.compositDisposable.Dispose();
        ICollection<IDisposable> IDisposableHolder.CompositeDisposable => this.compositDisposable;

        public string Name => "LevelGraph";

        public object View => new UserControl1();
    }
}