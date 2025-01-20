namespace Maui_WorkingDemo;

public partial class ContactsPage : ContentPage
{
    private readonly LocalDbService _dbService;
    private int _editCustomerId;

	public ContactsPage(LocalDbService dbService)
	{
		InitializeComponent();
        _dbService = dbService;
        Task.Run(async()=> listView.ItemsSource = await _dbService.GetCustomers());
    }

    private async void saveButton_Clicked(object sender, EventArgs e)
    {
        //if custId is passed, edit the record in db
        //else add new record
        if (_editCustomerId == 0)
        {
            //add new entry
            await _dbService.Create(new Contacts
            {
                ContactName = nameEntryField.Text,
                Email = emailEntryField.Text,
                Mobile = mobileEntryField.Text
            });
        }
        else
        {
            //edit
            await _dbService.Update(new Contacts
            {
                Id= _editCustomerId,
                ContactName = nameEntryField.Text,
                Email = emailEntryField.Text,
                Mobile = mobileEntryField.Text
            });
            //reset the Id
            _editCustomerId = 0;
        }
        //clear out UI fields
        nameEntryField.Text=string.Empty;
        emailEntryField.Text=string.Empty;  
        mobileEntryField.Text=string.Empty;

        //reload data from DB to ensure the data is stored correctly
        listView.ItemsSource = await _dbService.GetCustomers();
    }

    private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var contacts = (Contacts)e.Item;
        var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

        switch (action)
        {
            case "Edit":
                _editCustomerId = contacts.Id;
                nameEntryField.Text = contacts.ContactName;
                emailEntryField.Text = contacts.Email;
                mobileEntryField.Text = contacts.Mobile;

                break;
            case "Delete":
                await _dbService.Delete(contacts);
                listView.ItemsSource=await _dbService.GetCustomers();
                break;
        }
    }
}