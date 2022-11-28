This file is going to help you navigate through the frontend code of our website.

The most important folders and files that we have coded, created and used are the following:

	/wwwroot/Uploads/Animals --> contains animal images uploaded from the website using data entries. These are displayed when navigating to the Our Animals! tab in our website.

	/wwwroot/Uploads/Products --> contains product images displayed by the Shop tab.

	/Areas/Identity/Pages/Account/Manage --> this folder has many files used for authentication. These are created by .NET. We use two different roles (Manager, Employee) across all our code to manage privileges, you can find these roles being declared mostly inside the navigation bar and the controllers. 

	/Controllers -->  We have five controllers:

		1. animalsController.cs: manages and connects all the views under /Views/animals to the database. It stores different functions for creating, editing and deleting animals on the website.

		2. employeesController.cs: manages and connects all the views under /Views/employees to the database. It stores different functions for creating, editing and deleting employees on the website.

		3. habitatsController.cs: manages and connects all the views under /Views/habitats to the database. It stores different functions for creating, editing and deleting the habitats on the website.

		4. HomeController.cs: connects all the views under /Views/Home to the database. It stores different functions for creating, editing and deleting the habitats on the website.

		5. salesController.cs: connects all the views under /Views/sales to the database. It stores different functions for the shop and the checkout page.


	Models, we have 12 models in total. 9 of those are used for this project. These models store the information coming from the database. Every model has a name similar to the ones on the table.


	The folder Views stores all the tabs,  HTML and majority of the CSS code for our website:

		/Views/animals --> Has the create, Delete, Details, Edit and Index pages for the animals data entry.

		/Views/employees --> Has the create, Delete, Details, Edit and Index pages for the employees data entry.

		/Views/habitats --> Has the create, Delete, Details, Edit and Index pages for the habitats data entry.

		/Views/Home --> Has the Dashboard.csthml (displayed as the Notifications tab in our website). Index.csthml file 
		which is the Home page of the website. OurAnimals.csthml dislays the information for the Our Animals! tab. 
		Report1.cshtml corresponds to Animal Report, Report2.cshtml corresponds to Revenue Report, and Report3.cshtml 
		corresponds to Employee Report, these reports were created using Looker Studio and using a query to extract 
		the data from our database.

		/Views/sales --> Has the Checkout.cshtml, Shop.cshtml and SuccessPage.cshtml pages.  Corresponding the Checkout, 
		Shop and Success pages shown in the website. 
	
		/Views/Shared --> Contains _Layout.cshtml which is the file that displays the top bar navigation.


