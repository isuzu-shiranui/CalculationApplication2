﻿using Plugin;
using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;

namespace CalculationApplication2.ViewModels
{
    public class MainWindowViewModel
    {
        [Import(typeof(IPlugin))]
        public IPlugin Plugin { get; set; }

        public MainWindowViewModel()
        {
            LoadPlugins();
        }

        /// <summary>
        /// プラグインを全て読みこんで、[Import]がついているプロパティに格納する。
        /// </summary>
        private void LoadPlugins()
        {
            //フォルダがなければ作る。
            string pluginsPath = Directory.GetCurrentDirectory() + @"\plugins";
            if (!Directory.Exists(pluginsPath)) Directory.CreateDirectory(pluginsPath);

            //プラグイン読み込み
            using (var catalog = new DirectoryCatalog(pluginsPath, "SummationPlugin.dll"))
            using (var container = new CompositionContainer(catalog))
            {
                if (catalog.LoadedFiles.Count > 0) container.SatisfyImportsOnce(this);
            }
        }
    }
}