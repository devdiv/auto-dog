﻿using System;
using System.Collections.Generic;
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
using Microsoft.Win32;
using System.IO;
using AutoDog.UI.Controls.Dialogs;
using AutoDog.Controls.FolderBrowserControl;
using AutoDog.ViewModels;
using AutoDog.Models;
using AutoDog.Logics;

namespace AutoDog.Windows.ProjectManager
{
    /// <summary>
    /// NewSolution.xaml 的交互逻辑
    /// </summary>
    public partial class NewSolution
    {
        private readonly ProjectViewModel _viewModel;
        public NewSolution()
        {
            _viewModel = new ProjectViewModel(DialogCoordinator.Instance);
            DataContext = _viewModel;

            InitializeComponent();
            this.DataContextChanged += (sender, args) => {
                var vm = args.NewValue as ProjectViewModel;
                if (vm != null)
                {
                    CollectionViewSource.GetDefaultView(vm.ProjectAlbums).GroupDescriptions.Clear();
                    CollectionViewSource.GetDefaultView(vm.ProjectAlbums).GroupDescriptions.Add(new PropertyGroupDescription("Artist"));
                }
            };
        }

        private void openFolderClick(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.parentWindow = this;
            if (folder.ShowDialog() == true)
            {
                locationCmb.Text = folder.FileName;
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            RunNewSolutionSteps();
        }

        private void RunNewSolutionSteps()
        {           
            string solutionPath = Common.ProjectLocalPath + "\\" + solutionName.Text;

            //如果解决方案存在，会导致冲突，提示冲突异常信息
            if (Directory.Exists(solutionPath))
            {
                MessageBox.Show("创建解决方案失败：存在名称冲突的解决方案！");
            }
            else
            {
                //如果解决方案不存在，则创建解决方案
                try
                {
                    //创建解决方案文件夹，并在文件夹中创建解决方案文件
                    string solutionFile = solutionPath + "\\" + solutionName.Text + ".adt";
                    Directory.CreateDirectory(solutionPath);
                    File.Create(solutionFile);

                    //确定选中工程类型
                    ProjectAlbum albumObj = (ProjectAlbum)myAlbums.SelectedItem;                    
                    
                    //创建工程文件夹，并在工程文件夹中添加工程文件
                    string projectPath = solutionPath + "\\" + projectName.Text;
                    string projectFile = projectPath + "\\" + projectName.Text + albumObj.ProjectExtension;
                    Directory.CreateDirectory(projectPath);
                    File.Create(projectFile);

                    #region 添加其他必要文件
                    //添加Config文件，用来进行参数配置
                    string configFileName = "App";
                    string configFile = projectPath + "\\" + configFileName + ".config";
                    File.Create(configFile);

                    //添加基本的应用文件
                    string commonFileName = "App";
                    string commonFile = projectPath + "\\" + commonFileName + albumObj.IncludeFileExtension;
                    #endregion
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CancleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private string selectedTemplateType = null;
        private void myAlbums_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                //ProjectAlbum albumObj = (ProjectAlbum)e.AddedItems[0];
                ProjectAlbum albumObj = (ProjectAlbum)myAlbums.SelectedItem;
                myTemplateType.Text = "类型：" + albumObj.TemplateType;
                myDescribe.Text = albumObj.Describe;
                selectedTemplateType = albumObj.TemplateType;
                if (selectedTemplateType != null) { this.btnSubmit.IsEnabled = true; }
                else { this.btnSubmit.IsEnabled = false; }
            }          
        }

        private void NewSolution_Loaded(object sender, RoutedEventArgs e)
        {
            this.locationCmb.Text = Common.ProjectLocalPath;
            this.btnSubmit.IsEnabled = false;
        }
    }
}
