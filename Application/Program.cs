using Application.ApiLogic;
using Application.ClientLogic;
using Application.SQLCommands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
IConfiguration configuration = builder.Configuration;
builder.Services.AddSingleton<IDBCommandFactory, SQLCommandFactory>();
builder.Services.AddSingleton<SignupUser>();
builder.Services.AddSingleton<SigninUser>();
builder.Services.AddSingleton<GetUser>();
builder.Services.AddSingleton<UpdateUsername>();
builder.Services.AddSingleton<UpdatePassword>();
builder.Services.AddSingleton<UpdateEmail>();
builder.Services.AddSingleton<AddJob>();
builder.Services.AddSingleton<GetUserJobs>();
builder.Services.AddSingleton<GetAllJobs>();
builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.AddSingleton<APIClient>();

builder.Services.AddServerSideBlazor();


builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options =>
{
	options.Cookie.Name = "MyCookieAuth";
	options.LoginPath = "/SignIn";
	options.AccessDeniedPath = "/Home";
	options.ExpireTimeSpan = TimeSpan.FromMinutes(5);//Persistant cookie sayesinde brower kapandıgında 5dk'nın sayımı duruyor Tekrar gelindiğinde kaldığı yerden devam ediyor.
});

builder.Services.AddAuthorization(configure =>
{
	configure.AddPolicy("Admin",// Bu şekilde bu politika ile girilen yerlerden kullanıcıdan 2 claim bekliyorum.
		policy => policy.RequireClaim("User", "POWER"));
});
builder.Services.AddAuthorization(configure =>
{
	configure.AddPolicy("User",// Bu şekilde bu politika ile girilen yerlerden kullanıcıdan 2 claim bekliyorum.
		policy => policy.RequireClaim("User", "Standart"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles(); // add this
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapBlazorHub();
app.Run();
