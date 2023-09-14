using NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NoteApp.ViewModels
{
    public partial class NoteViewModel : INotifyPropertyChanged
    {
        private string _noteTitle;
        private string _noteDescription;
        private Note _selectedNote;


        public ObservableCollection<Note> NotesCollection { get; set; }
        public ICommand AddNoteCommand { get;}
        public ICommand EditNoteCommand { get; }
        public ICommand RemoveNoteCommand { get; }

        public NoteViewModel()
        {
            NotesCollection = new ObservableCollection<Note>();
            AddNoteCommand = new Command(AddNote);
            EditNoteCommand = new Command(EditNote);
            RemoveNoteCommand = new Command(RemoveNote);
        }

        private void RemoveNote(object obj)
        {
            if(SelectedNote != null)
            {
                NotesCollection.Remove(SelectedNote);
                NoteTitle = string.Empty;
                NoteDescription = string.Empty;
            }
        }

        private void EditNote(object obj)
        {
            if (SelectedNote != null)
            {
                foreach(Note note in NotesCollection.ToList()) 
                {
                    if (note==SelectedNote)
                    {
                        Note newNote = new Note
                        {
                            Id = note.Id,
                            Title=NoteTitle,
                            Description=NoteDescription
                        };
                        NotesCollection.Remove(note);
                        NotesCollection.Insert(newNote.Id,newNote);
                        NoteTitle = string.Empty;
                        NoteDescription = string.Empty;
                    }
                }
            }
        }

        private void AddNote(object obj)
        {
            int newid = NotesCollection.Count > 0 ? NotesCollection.Max(p => p.Id) + 1 : 0;
            var note =new Note
            { 
                Id = newid,
                Title = NoteTitle,
                Description = NoteDescription,
            };
            NotesCollection.Add(note);
            NoteTitle=string.Empty;
            NoteDescription=string.Empty;
        }

        public string NoteTitle
        {
            get { return _noteTitle; }
            set 
            {
                if(_noteTitle!=value)
                {
                    _noteTitle = value;
                    onPropertyChanged();
                }
            }
        }
        public string NoteDescription
        {
            get { return _noteDescription; }
            set
            {
                if (_noteDescription != value)
                {
                    _noteDescription = value;
                    onPropertyChanged();
                }
            }
        }
        public Note SelectedNote
        {
            get { return _selectedNote; }
            set
            {
                if ( _selectedNote != value)
                {
                    _selectedNote = value;
                    NoteTitle=SelectedNote.Title;
                    NoteDescription=SelectedNote.Description;
                    onPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void onPropertyChanged([CallerMemberName] string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
