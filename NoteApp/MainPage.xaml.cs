﻿namespace NoteApp;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
		container.Content=new Views.NoteView();
	}

	
}

