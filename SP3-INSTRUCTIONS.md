# Self-Promotion Site Assignment 3

The first goal of this assignment is to migrate your SP2 assignment over to this one and "scaffold" the ASP.NET Core Identity into the migrated project.

## Step 0) Open the Assignment in Codespaces

Likely you're already here using Codespaces. But if by some strange set of circumstances you are not, then "Code" this repository using Codespaces.

NOTE: You CAN run this locally by running `git clone [repo]` and opening the resulting directory in VS Code on your local machine. Nothing special here. As long as you have .NET 7 or newer installed, it should work fine. But that's an "unsupported" option, so do so at your own risk. Okay, I'll likely still support you, but it's still slightly risky'er. 😉

## Step 1) Copy your SP2 Assignment

There are many ways to go about this. You just want the complete set of "non-dot" files and folders from your self-promo-FIRSTNAME directory. We'll do it the most "manual" way using downloads and drag-n-drop.

  > NOTE: I reference `FIRSTNAME` a LOT below as part of the project name, project namespace, commands, etc. __**MAKE SURE YOU REPLACE THIS WITH YOUR FIRST NAME**__!!

1) In a new tab, Navigate to your SP2 repository on the GitHub website (e.g., https://github.com/au-csci3600-23fa/self-promo-2-ptyork ... though obviously replacing your GitHub username for `ptyork`)
2) Click the [`<> Code v`] button, select the Local tab, and click Download ZIP (note the location you download the file to)
3) Return to the Codespaces tab for SP3 and ensure the "Explorer" tab is visible
4) Right-click in the Explorer pane on an empty space (e.g., directly below README.md)
5) Select "Upload..." from the context menu, locate your downloaded SP2 ZIP file, and click "Open" to upload it to Codespaces
6) In Codespaces, right-click on the `self-promo-2-USERNAME-main.zip` FILE you just uploaded and select "Mount Zip"
    * This will cause your Codespace to refresh...don't panic)
    * You should now have a `self-promo-2-USERNAME-main.zip` FOLDER expanded showing the contents of your SP2 submission
    * NOTE: this feature is part of a ZipFS extension, so you won't see it if you do this locally
7) Right-click on the `self-promo-FIRSTNAME` project folder from the "mounted" zip folder and `Copy` it
8) Right-click on the root `self-promo-3-USERNAME` folder at the top of the explorer window and `Paste` your project folder there
9) Right click on the mounted zip FOLDER and Unmount it
10) Right click on the zip FILE and Delete it

9 & 10 aren't strictly necessary, but I recommend it to avoid accidentally modifying the contents of your old project, which I won't be grading and will just be confusing.

Now let's just make sure everything worked.

1) In the Terminal window, change to your project directory (`cd self-promo-FIRSTNAME`)
2) Run your project (`dotnet watch`)
3) Check the output
    * Switch from "Terminal" to "Ports" tab
    * Find the 500_ port
    * Hover over forwarded address URL and click the globe

With luck, all is well. If not, double and then triple check the above directions. If you're pretty sure your doing everything as instructed and still having issues, then reach out via the Assignment Questions channel in Teams.

## Step 2) Scaffold Identity Into Your Project

These directions are loosely following [this tutorial](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-7.0&tabs=netcore-cli), so if you run into issues, you may wish to check there to see if it offers a better explanation or troubleshooting tips.

Switch back to the Terminal and Press Ctrl+C to to terminate your `dotnet watch` process.

  > NOTE: You'll need to terminate this process a number of times to run other tools or restart the testing. I won't tell you when this is needed each time as it should be obvious.

The first thing we'll need to do is to install the .NET Entity Framework tooling. So run the following at the terminal.

```
dotnet tool install --global dotnet-ef
```

Now run the following command to install the "scaffolding" tooling.

```
dotnet tool install -g dotnet-aspnet-codegenerator
```

Next run each of the following to add the required packages to the CSPROJ file and download them from the NuGet package repository.

```
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Identity.UI
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

  > NOTE: this is slightly different from the referenced tutorial as we're also adding the Sqlite provider.

Next, add in the files required to add the Identity database context by running that scaffolding tool.

```
dotnet aspnet-codegenerator identity --useDefaultUI --databaseProvider=sqlite
```

Finally, create and initialize the identity database by creating and running an Entity Framework migration.

```
dotnet ef migrations add CreateIdentitySchema
dotnet ef database update
```

At this point, you should have created the database. It'll be in the root of your project and should be called `self-promo-FIRSTNAME.db`. In the Explorer tab, locate this file and click on it. This should load the Sqlite Editor extension and you should be able to view the tables that are now part of this database. Don't do anything with it. Just verify that it's there.

## Step 3) Disable Email Verification

This one is simple. The problem is that we don't HAVE an email server. Also, the built-in, hack page for this (click here to pretend that you've verified your email address) hard codes the link to point to localhost. Well, when running via Codespaces, you are NOT connecting to localhost, you're connecting to a proxy. So it's borked.

We'll just disable it.

Open Program.cs. Find the `builder.Services.AddDefaultIdentity` line. Change the `options.SignIn.RequireConfirmedAccount` to `false`. You can actually just remove this entire Lambda expression since the default is false, but we'll be explicit here just for fun.

## Step 4) Add Login/Logout to your site's navigation

We now need to modify the _Layout.cshtml page a bit. It needs the Register/Login/Account/Logout links. And to support those, we need a couple of "sections" added to the support scripts and such. We need those later, anyway, so cool.

Open _Layout.cshtml from the Pages/Shared folder. At the bottom of the `<head>` section you want to add an optional section that we can use later to add additional styles and/or scripts. Also, since these pages will used jQuery behind the scenes, we'll go ahead an import the jQuery script. So right above your `</head>` add the following.

```
  <script src="~/lib/jquery/dist/jquery.min.js"></script> 
  @RenderSection("Head", false)
```

You ALSO want an optional section for scripts at the very end of your layout. This one is actually needed by the default Identity pages, so we'll definitely need to add this one just to get things working. So right above your `</body>`, add the following.

```
  @RenderSection("Scripts", false)
```

Locate your `<nav>` element. Assuming you finished SS7, your links should all be inside of an unordered list. AFTER the last `</li>` but before the `</ul>` you want to add a reference to the login partial view that the identity scaffolding added for us. Will end up looking a bit like this:

```
  <nav>
    <ul>
      <li><a href="~/Index">Home</a></li>
      <li><a href="~/Education">Education</a></li>
      <li><a href="~/Experience">Experience</a></li>
      <li><a href="~/Gallery">Photo Gallery</a></li>
      <partial name="_LoginPartial" />
    </ul>
  </nav>
```

Now you need to modify the _LoginPartial.cshtml file a bit. This is because you want to add the login/logout links to the existing nav list and the current partial assumes you are adding an entirely new one. It's also because it's convoluted and we can make it "better."

Make the _LoginPartial.cshtml file look like this. It's really not much different, except that we're replacing all of the complex URL syntax (meant really for MVC, not RazorPages) with simpler root-relative URLs. AND we're replacing the `<button>` with a standard link...though this DOES require we shove in a wee bit 'o the JavaScript.

```
@using Microsoft.AspNetCore.Identity

@inject SignInManager<IdentityUser> SignInManager
@inject UserManager<IdentityUser> UserManager

@if (SignInManager.IsSignedIn(User))
{
    <li>
        <a href="~/Identity/Account/Manage/">Hello @UserManager.GetUserName(User)!</a>
    </li>
    <li>
        <form id="logoutForm" method="post" action="~/Identity/Account/Logout" style="display:inline">
            <a href="#" onclick="document.querySelector('#logoutForm').submit();return false;">Logout</a>
        </form>
    </li>
}
else
{
    <li>
        <a href="~/Identity/Account/Register/">Register</a>
    </li>
    <li>
        <a href="~/Identity/Account/Login/">Login</a>
    </li>
}
```

Now do a `dotnet run` or `dotnet watch` and test things out. You SHOULD be able to register and log in and log out and even manage your account. FUN!!!

## Step 5) Make the Database our Own

The data context class was created in a strange `Areas/Identity/Data` folder. This makes sense if you're going to have two separate databases (one for login stuff and one for your application). But that's NOT what WE'RE going to do. We want one, big, happy database.

So let's clean this up a bit. First, let's move the context class.

  1) create a Data directory in the project root. I.e., `/self-promo-FIRSTNAME/Data` (here on I'll call this `~/Data`)
  2) MOVE `Areas/Identity/Data/IdentityDataContext.cs` into `~/Data`
  3) RENAME `~/Data/IdentityDataContext.cs` to be `~/Data/SelfieDataContext.cs`
  4) Open SelfieDataContext.cs and
      * Change the namespace to `self_promo_FIRSTNAME.Data`
      * Change the class name, constructor method name and the generic type name to `SelfieDataContext`

Now we need to modify `Program.cs` so that it uses this new data context class instead of the default one. This is easy enough. In Program.cs:

  1) Change `using self_promo_FIRSTNAME.Areas.Identity.Data` to `using self_promo_FIRSTNAME.Data`
  2) Change `AddDbContext<IdentityDataContext>` to `AddDbContext<SelfieDataContext>`
  3) Change `AddEntityFrameworkStores<IdentityDataContext>` to `AddEntityFrameworkStores<SelfieDataContext>`
  4) And just to be thorough (some might call it "retentive"), change `GetConnectionString("IdentityDataContextConnection")` to `GetConnectionString("SelfieConnection")`
      * You will ALSO need to open up ~/appsettings.json and change "IdentityDataContextConnection" to "SelfieConnection"

Finally, we need to remove any migrations as well as the database. This is because these will contain a reference to the old `IdentityDataContext` and it will cause errors during the build.

  1) In the explorer view, locate and delete the `Areas/Identity/Data/Migrations`` folder
  2) Then ALSO delete `self_promo_FIRSNAME.db` from the project root
  3) Now we have to recreate the database using our "new" `SelfieDataContext`, so rerun the following from the terminal

```
    dotnet ef migrations add CreateIdentitySchema
    dotnet ef database update
```

  > NOTE: I know many of you will think I'm being silly by changing all of the above, but there's a pedagogical reason for it. I want you to get a feel for how all of these pieces tie together. Nothing is "magic" here. It's all just code.

Go ahead and `dotnet run` this again to make sure everything works. Nothing should have changed. We just cleaned up a bit.

## Step 6) Add Some New Entities

Our goal here is to allow you to modify your resume quickly using the database. You will have Experiences and each Experience will have Responsibilities. This should "feel" familiar as this is actually how your page looks. We'll just be making these database driven.

Experience to Responsibility is a one-to-many relationship, which may sound complicated. But in reality it's pretty simple. We just create navigation properties to help us move from a parent object to child objects (experience to responsibilities) and from child object back to parent (responsibility to experience). It's intuitive. Trust me.

In the ~/Data folder, create two C# class files: `Experience.cs` and `Responsibility.cs`.

The first lines of each of these files should be:

```
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace self_promo_FIRSTNAME.Data;
```

Each file will contain a single class declaration.

START with this for `Experience.cs`

```
public class Experience
{
    public int ExperienceId { get; set; }
    public string Company { get; set; } = default!;
    public string JobTitle { get; set; } = default!;
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public string Description { get; set; } = default!;
    public bool IsProfessional { get; set; }

    // Navigation property to access "children"
    public ICollection<Responsibility> Responsibilities { get; set; } = new List<Responsibility>();
}
```

and this for `Responsibility.cs`

```
public class Responsibility
{
    public int ResponsibilityId { get; set; }
    public string Value { get; set; } = default!;

    // Foreign Key field (referencing "parent")
    public int ExperienceId { get; set; }

    // Navigation property (referencing "parent")
    public Experience? Experience { get; set; }
}
```

  > NOTES: (a) The `= default!` part is a way of getting around warnings about null references not having a value when exiting the constructor. (b) Despite the fact that the documentation CLEARLY says it's not required, in order for the validation to work properly, I had to make the Responsibility.Experience navigation property nullable (the ? after the Experience type declaration). This WILL cause warnings on the Admin/Responsibilities pages, but they can be safely ignored.

You will need to add annotations to the public properties to support the attributes defined below.

_**Experience**_

  * ExperienceId
    * primary key
  * Company
    * required
    * max length is 100 characters
  * JobTitle
    * required
    * max length is 100 characters
  * StartDate
    * required
  * Description
    * required
    * max length is 5000 characters

__**Responsibility**__

  * ResponsibilityId
    * primary key
  * Value
    * required
    * max length is 150 characters

The annotations needed for the above are:

  * `[Key]` (for primary key **only**)
  * `[Required]`
  * `[MaxLength(####)]`

Finally, in your SelfieDataContext.cs file add the following as the last members of this class.

```
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Responsibility> Responsibilities { get; set; }
```

This is where we are **actually** creating the tables to store your stuff.

That's it for the data model. You should likely do a `dotnet build` in the terminal window to make sure everything still builds and work through any errors.

And if all is well, we now just need to update our database. First we create a new migration that will generate the SQL needed to add these tables to our database. And then we just update the database. So back at the Terminal, run the following.

```
dotnet ef migrations add CreateExperienceTables
dotnet ef database update
```

  > NOTE: if the update fails and you need to remove the migration, you can run `dotnet ef migrations remove`. If you forgot to add a field or just want to create ANOTHER migration, this is fine. Just use a different "name" (e.g., `dotnet migrations add FixExperienceModel`)

Assuming you get no errors, then we can move on. But before we do, click on the `self-promo-FIRSTNAME.db` file in the explorer. Note the two new tables added (Experiences and Responsibilities). We did it!!

## Step 7) Create an Experience Management System

This sounds daunting. It's not bad. You DO need a way to do the CRUD on these two new tables. But we'll just hack one together using some scaffolding tools.

From the terminal, enter the following.

```
dotnet aspnet-codegenerator razorpage -m Experience -dc self_promo_FIRSTNAME.Data.SelfieDataContext -udl -outDir Pages/Admin/Experiences --referenceScriptLibraries
```

Assuming you copy/pasted properly and changed FIRSTNAME to be your actual first name, this SHOULD create a full set of pages to create, read, update and delete experiences from the database. DONE!

Well almost. We need to do the same for Responsibilities.

```
dotnet aspnet-codegenerator razorpage -m Responsibility -dc self_promo_FIRSTNAME.Data.SelfieDataContext -udl -outDir Pages/Admin/Responsibilities --referenceScriptLibraries
```

And of course we need to test it out. Do a `dotnet run` from the terminal and browse to the normal home page. Then append `/Admin/Experiences` to the end of the URL to navigate to your Experiences admin page. Do the same for Responsibilities.

## Step 8) "Protect" the Admin Pages

Ideally, ONLY YOU could register for your site. But let's at least make is so that only people who are logged in can use the Admin pages. This involves a few steps.

  1) Add the appropriate annotation to all of the Admin page models so that you have to be authenticated to access them.
  2) Add an Admin/Index page and page model. The page should JUST have links to the two admin pages (`~/Admin/Experiences` and `~/Admin/Responsibilities`). Put 'em in a list or something to make them prettyish. ALSO protect this page's model with the appropriate annotation.
  3) Modify your _Layout.cshtml page. Add an `<a>` to your `<nav>` that links to the above Admin page (`~/Admin`). Put an @if block around it to insure it is only shown if you are logged in. Refer to the login partial page for insight on how to do this (HINT: you'll need the @using and @inject statements to be able to access the SignInManager.IsSignedIn method).

## Step 9) Add Experiences and Responsibilities

Again this is pretty simple. Use these pages to add experiences and responsibilities. Since responsibilities will reference an experience, you should enter the experiences first. Then add the associated responsibilities.

So, navigate to the `/Admin/Experiences` and `/Admin/Responsibilities` pages as required to add (or update) this data.

If it isn't clear, this is nothing more than copy/pasting from your current "hard coded" Experience page.

## Step 10) Database'ify your Experience PageModel

Now you want to make your Experience page actually build itself using the database you've created and populated.

The first step is to make sure that you have an appropriate PageModel for your Experience page. So open `~/Pages/Experience.cshtml.cs` and make some changes.

First we need to make sure we reference the namespace that contains the new data models. So add the following at the top:

```
using self_promo_FIRSTNAME.Data;
```

Now inside of the class declaration, you'll want a couple of collections to hold your experiences. Remember you have BOTH professional and activity experiences. So one collection for each.
Add the following properties near the top of your class body.

```
    public ICollection<Experience> ProfessionalExperiences { get; set; } = default!
    public ICollection<Experience> Activities { get; set; } = default!
```

You also want to use your database context to retrieve data from the database. So you'll need to add a place to "remember" that so that you can use dependency injection to request it in the constructor. So just below the above properties, add the following private field.

```
    private readonly SelfieDataContext _context;
```

Your constructor will need to be modified to "ask" for a data context object, so change it to match the following.

```
    public ExperienceModel(SelfieDataContext context, ILogger<ExperienceModel> logger)
    {
        _context = context;
        _logger = logger;
    }
```

You'll now need to retrieve the experiences form the database on the page load. This will use async methods, so you'll need to replace your OnGet() method with an OnGetAsync() method.

```
    public async Task OnGetAsync()
    {
        // query the database here
    }
```

Inside of the OnGetAsync you'll want to query the database TWICE. The first should retrieve all professional experiences. The second should retrieve all activities (non-professional experiences). I'll give you the first query. I think you can figure out the second.

```
        this.ProfessionalExperiences = await _context.Experiences
            .Include(e => e.Responsibilities)
            .Where(e => e.IsProfessional == true)
            .ToListAsync();
```

  > NOTE: The ".Include" there is pre-fetching the responsibilities for each experience. Otherwise this navigational property would be empty by default. This may be a clue as to how to earn some extra credit.

## Step 11) Database'ify your Experience Page

The final step is to actually add the code in your experience page to pull the data from the page model.

For the Professional Experience section, add an @foreach to loop through each experience in your Model.ProfessionalExperiences collection.
    
1) Inside of the loop copy ONE of your experiences (i.e., everything from the `<div class="experience">` to the closing `</div>` ...including the `<div>` & `</div>` themselves)
2) Replace the "hard coded" experience with data drawn from the Experience objects
    * E.g., if you have `@foreach (var exp in Model.ProfessionalExperiences)`, you might have `<h4>@exp.Company</h4>` for your company name.
    * Hint: See http://www.csharp-examples.net/string-format-datetime/
        * Even Stronger hint: use something like `String.Format("{0:y}", exp.StartDate)`
2) You will have to have ANOTHER @foreach loop to write out each of the responsibilities in the `<ul>`. Will be something like `@foreach (var resp in exp.Responsibilities)` and you'll have `<li>@resp.Value</li>` or similar to iterate over the whole collection.

Now the challenge is to get the end date to say "Present" if the end date is null...not gonna give you the full answer, though you should likely use a code block to create a variable and/or perhaps a ternary operator (if you're that cool).

Also use @if when and where needed to handle weird things like empty lists of responsibilities. I.e., don't display the responsibilities div if there are no responsibilities in the list.

When you're done, copy and paste that loop into your "Activities" section and repeat for the Model.Activities list. It'll be identical except for the collection you're iterating over.

Now test it. Okay, unless you're sadistic, you've been testing along the way. But DEFINITELY test it now. If all goes well, nothing on your Experience page will have changed from your prior submission.

DANG! That was a lot of work for no change!!!

## STEP 42) Optional challenge exercises

If you take on any of these, make sure you let me know in the submission comment on D2L so that I know to look for them.

  1) (2 pts+) For the first person to file a unique "bug report" on these instructions. Not something silly or just a tiny typo (unless it causes things to break and the fix isn't obvious), but a missing or incorrect step, something described incorrectly, etc.
  2) (5 pts) The experiences are coming out of the database in no particular order. Add an OrderBy() to your two queries in the controller to sort the experiences so that they display newest to oldest.
  3) (5 pts) The responsibilities are stored and retrieved in no particular order. Add a "SequenceNumber" int property to the responsibilities to allow you order the responsibilities in your query. Must add sequence numbers to all responsibilities and add sorting to both professional and activity queries to get credit.
  4) (5 pts) In the Responsibilities/Details and Responsibilities/Delete pages there's a bug where it always shows an empty string where they INTEND to show the company name. This is because the Experience isn't being included in the query. Look at `OnGetAsync` in the page model for Responsibilities/Index. See if you can figure out what's different and make the same change to the other two page models to fix this bug.
  5) (5 pts) The forms are FUGLY. Work on the CSS so that the Register, Login and Admin forms are acceptable. The default ASP.NET templates all assume you're using Bootstrap. We won't be, but you can look in the Bootstrap css file for inspiration. Or just wing it.
  6) (10 pts) The process of adding responsibilities to an experience is really awkward. Ideally your Experiences/Details page would show a list of the responsibilities associated with that particular experience (like the Experiences page already does). Basically adding the Responsibilities/Index page to the bottom of the Responsibilities/Details page. You could then add responsibilities from there instead of having to go to the Responsibilities/Index page to Create them and then associating the new ones with the experience using the drop down. See if you can figure out a way to modify both the Experience/Details page and the Responsibilities/Create and Responsibilities/Edit pages to use a hidden field instead of a drop down so that the relationship is automatically set. You'll also need to modify the ResponsibilityModel to pull the id from the Request.Forms field on Post. This isn't easy. But it is something that you SHOULD be able to do if you really dig deep.

## Step 69) Test and Submit

When you are done, make sure you've tested it. Then click on the Source Control tab, **enter a commit message**, and Commit & Sync this to GitHub.

Don't forget to double check that the code is all there by either clicking on the GitHub classroom link again and opening the repository from there or by going directly to the repository at https://www.github.com/au-csci3600-23fa/self-promo-3-YOURID/


## Step 8675.309) Whew!