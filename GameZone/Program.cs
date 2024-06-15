using AspNetCore.ReCaptcha;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(op =>
      op.UseSqlServer(builder.Configuration.GetConnectionString("myCon")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>() //adding IdentityRole Table to the service, to give roles for users 
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddReCaptcha(builder.Configuration.GetSection("ReCaptcha"));


builder.Services.AddTransient<IEmailSender, clsEmailConfirm>();

builder.Services.AddScoped<ICategoriesService , CategoriesService>();
builder.Services.AddScoped<IGamesService , GamesService>();
builder.Services.AddScoped<IDevicesService , DevicesService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "area",
//    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoint => endpoint.MapRazorPages());
app.Run();
