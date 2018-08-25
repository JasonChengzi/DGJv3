﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DGJv3
{
    /// <summary>
    /// DGJWindow.xaml 的交互逻辑
    /// </summary>
    internal partial class DGJWindow : Window
    {
        public DGJMain PluginMain { get; set; }

        public ObservableCollection<SongItem> Songs { get; set; }

        public Player Player { get; set; }

        public Downloader Downloader { get; set; }

        public Writer Writer { get; set; }

        public DGJWindow(DGJMain dGJMain)
        {
            DataContext = this;
            PluginMain = dGJMain;
            Songs = new ObservableCollection<SongItem>();
            Player = new Player(Songs);
            Downloader = new Downloader(Songs);

            InitializeComponent();

            #region PackIcon 问题 workaround

            PackIconPause.Kind = MaterialDesignThemes.Wpf.PackIconKind.Pause;
            PackIconPlay.Kind = MaterialDesignThemes.Wpf.PackIconKind.Play;
            PackIconVolumeHigh.Kind = MaterialDesignThemes.Wpf.PackIconKind.VolumeHigh;
            PackIconSkipNext.Kind = MaterialDesignThemes.Wpf.PackIconKind.SkipNext;
            PackIconSettings.Kind = MaterialDesignThemes.Wpf.PackIconKind.Settings;

            #endregion

        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}