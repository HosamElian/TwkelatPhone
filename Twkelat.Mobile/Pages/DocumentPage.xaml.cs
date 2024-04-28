using Twkelat.Mobile.Models;
using Twkelat.Mobile.Repositories;
using Twkelat.Mobile.Services.IServices;

namespace Twkelat.Mobile.Pages;

public partial class DocumentPage : ContentPage
{
    private readonly IDelegationRepository _delegationRepository;
    List<Templete> _templetes;
    public DocumentPage(IDelegationRepository delegationRepository)
	{
		InitializeComponent();
        _delegationRepository = delegationRepository;
        _templetes = _delegationRepository.GetAllTemplete();
        templeteViewer.Title = "Select a Templete";
        templeteViewer.ItemsSource = _templetes;
        templeteViewer.ItemDisplayBinding = new Binding(nameof(Templete.Name));
    }

    private void templeteViewer_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        if (selectedIndex != -1)
        {
            var text = _delegationRepository.GetAllTemplete()
                .FirstOrDefault(c=>c.Id == _templetes[selectedIndex].Id)?.Message ?? "";
            entryView.Text = text;

            picker.SelectedIndex = selectedIndex;
        }
    }
}