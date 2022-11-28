Hello, this file is going help navigate through the the zoo database website files 
and where the source for everything is located

Login and Register:
	To find the source for login and register you can go to /Areas/Identity/Pages/Account
	this is where code, oth front and back,are located for the login pages

Tabs:
	The zoo data base has three tabs for customers, Home, Our Animals!, Shope
	
	Home:
		For the source for the home page of our website, you can go to /Views/Home/Index.cshtml
	Shop: 
		for the shops tab, you can go to the /Views/sales/
		

	OurAnimals:
		For the source for the home page of our website, you can go to /Views/Home/OurAnimals.cshtml

	There are other pages available only to users with certain roles, one of them being employee, whether 
	it be one working at habitat, restaraunt, or gift shop, they have access to animal report, Animal Data Entry
	and habitat data entry.
	Report on Animals:
		For the source for the first report, the animal report, you can go to /Views/Home/Report1.cshtml
	Animal Data entry:
		For the source for the animal data entry, you can go to /Views/animals/ 
	Habitat Data entry:
		For the source for the habitat data entry, you can go to /Views/habitats/

	The last, but not least, role on our website is the admin role, they can look at everything a customer and 
	employee can, but also the last 2 reports concerning the company revenues and also the ones concerning 
	employees, they also have access to Employee data entry 

	Report on Revenue:
		For the source for the second report, the revenue report, you can go to /Views/Home/Report2.cshtml
	Report  on Employee:
		For the source for the third report, the Employee report, you can go to /Views/Home/Report3.cshtml
	Employee Data Entry:
		For the source for the habitat data entry, you can go to /Views/habitats/employees
	To access the class files for everything from animals to items to habitats, you can head to /Models/
	To know about how they are created you can head to /Data/