using NoteApp.ViewModels;

namespace NoteApp.Views;

public partial class NoteView : ContentView
{
    private readonly NoteViewModel model;

    public NoteView(NoteViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
        this.model = model;
    }

    private void NoteList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        model.SetData();
    }
}