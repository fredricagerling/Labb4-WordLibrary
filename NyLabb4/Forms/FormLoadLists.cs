﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordLibrary;

namespace NyLabb4
{
    public partial class FormLoadLists : Form
    {
        public WordList LoadedList { get; private set; }
        public event EventHandler ButtonSelectClicked;

        public FormLoadLists()
        {
            InitializeComponent();
            createNewList.AddNewList += CreateNewList_AddNewList;
        }

        private void CreateNewList_AddNewList(object sender, EventArgs e)
        {
            LoadLists();
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (listBoxLists.SelectedItem == null) { Close(); return; };
            
            LoadedList = WordList.LoadList(listBoxLists.SelectedItem.ToString());
            ButtonSelectClicked?.Invoke(this, null);

            Close();
        }

        private void listBoxLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxLanguages.Items.Clear();
            LoadedList = WordList.LoadList(listBoxLists.SelectedItem.ToString());
            labelWordCounter.Text = LoadedList.Count().ToString();
            for (int i = 0; i < LoadedList.Languages.Length; i++)
            {
                listBoxLanguages.Items.Add(LoadedList.Languages[i]);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonNewList_Click(object sender, EventArgs e)
        {
            FormCreateNewList createNewList = new FormCreateNewList();
            createNewList.ShowDialog();
        }

        private void FormLoadLists_Load(object sender, EventArgs e)
        {
            LoadLists();
        }

        private void LoadLists()
        {
            listBoxLists.Items.Clear();
            string[] lists = WordList.GetLists();
            for (int i = 0; i < lists.Length; i++)
            {
                listBoxLists.Items.Add(lists[i]);
            }
        }
    }
}