﻿using Ookii.Dialogs.Wpf;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace glTF
{
    public partial class UnpackWindow : Window
    {
        private string inputFilePath;

        public UnpackWindow(string inputFilePath, string outDirectoryPath)
        {
            InitializeComponent();

            /*this.inputFilePath = inputFilePath;
            var inputDirectoryPath = Path.GetDirectoryName(this.inputFilePath);
            var inputFileName = Path.GetFileNameWithoutExtension(this.inputFilePath);*/
            /*this.Folder.Text = GetUniqueDirectoryPath(Path.Combine(inputDirectoryPath, inputFileName));
            this.Folder.SelectAll();
            this.Folder.Focus();*/

            UnpackGLB(inputFilePath, outDirectoryPath);
        }


        private static string GetUniqueDirectoryPath(string baseDirectoryPath)
        {
            var directoryPath = baseDirectoryPath;

            for (var index = 2; index < 100; index++)
            {
                if (!Directory.Exists(directoryPath))
                {
                    break;
                }

                directoryPath = $"{baseDirectoryPath} ({index})";
            }

            return directoryPath;
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new VistaFolderBrowserDialog
            {
                ShowNewFolderButton = true,
                SelectedPath = this.Folder.Text,
            };

            if (dialog.ShowDialog(this).Value)
            {
                this.Folder.Text = dialog.SelectedPath;
            }
        }

        private void Unpack_Click(object sender, RoutedEventArgs e)
        {
            var tempDirectoryPath = Path.Combine(Path.GetTempPath(), $"glTF.{Guid.NewGuid()}");

            Directory.CreateDirectory(tempDirectoryPath);

            try
            {
                Unpacker.Unpack(this.inputFilePath, tempDirectoryPath, this.UnpackImages.IsChecked.Value);

                var outputDirectoryPath = this.Folder.Text;
                Directory.CreateDirectory(outputDirectoryPath);

                foreach (var filePath in Directory.EnumerateFiles(tempDirectoryPath))
                {
                    var outputFilePath = Path.Combine(outputDirectoryPath, Path.GetFileName(filePath));

                    if (File.Exists(outputFilePath))
                    {
                        File.Delete(outputFilePath);
                    }

                    File.Move(filePath, outputFilePath);
                }

                if (this.OpenFolder.IsChecked.Value)
                {
                    Process.Start(outputDirectoryPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Unpack Error");
            }

            Directory.Delete(tempDirectoryPath, true);
            this.Close();
        }

        private void UnpackGLB(string inputFile, string outputDir)
        {
            var tempDirectoryPath = Path.Combine(Path.GetTempPath(), $"glTF.{Guid.NewGuid()}");

            Directory.CreateDirectory(tempDirectoryPath);

            try
            {
                Unpacker.Unpack(inputFile, tempDirectoryPath, true);

                var outputDirectoryPath = outputDir;
                Directory.CreateDirectory(outputDirectoryPath);

                foreach (var filePath in Directory.EnumerateFiles(tempDirectoryPath))
                {
                    var outputFilePath = Path.Combine(outputDirectoryPath, Path.GetFileName(filePath));

                    if (File.Exists(outputFilePath))
                    {
                        File.Delete(outputFilePath);
                    }

                    File.Move(filePath, outputFilePath);
                }

                /*if (this.OpenFolder.IsChecked.Value)
                {
                    Process.Start(outputDirectoryPath);
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Unpack Error");
            }

            Directory.Delete(tempDirectoryPath, true);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Folder_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Warning.Visibility = Directory.Exists(this.Folder.Text) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
