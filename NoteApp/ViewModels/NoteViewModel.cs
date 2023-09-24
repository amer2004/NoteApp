using NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using NoteApp.DataBase;

namespace NoteApp.ViewModels
{
    public partial class NoteViewModel :ObservableObject
    {
        DataBaseContext db;

        [ObservableProperty]
         string noteTitle;

        [ObservableProperty]
         string noteDescription;

        [ObservableProperty]
         Note selectedNote;

        [ObservableProperty]
         ObservableCollection<Note> notesCollection;
        NoteEntity DataHelper;
  
        public NoteViewModel()
        {
            notesCollection = new ObservableCollection<Note>();
            DataHelper= new NoteEntity();
            LoadData();
        }

        [RelayCommand]
        private async void RemoveNote(object obj)
        {
            if(SelectedNote != null)
            {
                await  DataHelper.RemoveDataAsync(SelectedNote);
                LoadData();
                NoteTitle = string.Empty;
                NoteDescription = string.Empty;
            }
        }
        [RelayCommand]
        private async void EditNote(object obj)
        {
            if (SelectedNote != null)
            {               
                Note newNote = new Note
                {
                            Id = SelectedNote.Id,
                            Title=NoteTitle,
                            Description=NoteDescription
                };
                await DataHelper.UpdateDataAsync(newNote);
                LoadData();
            }
        }
        [RelayCommand]
        private async void AddNote(object obj)
        {         
            var note =new Note
            {      
                Title = NoteTitle,
                Description = NoteDescription,
            };
            await DataHelper.AddDataAsync(note);
            LoadData();
            NoteTitle=string.Empty;
            NoteDescription=string.Empty;
        }
        public void SetData()
        {
            NoteTitle = SelectedNote.Title;
            NoteDescription = SelectedNote.Description;
        }
        public async void LoadData()
        {
            NotesCollection.Clear();
            foreach (var note in await DataHelper.GetAllAsync())
            {
                NotesCollection.Add(note);
            }
        }
    }
}
