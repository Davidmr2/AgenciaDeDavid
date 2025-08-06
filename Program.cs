using AgenciaDeDavid.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// 1. Agregar el contexto de base de datos con cadena de conexión
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Agregar soporte para controladores y vistas
builder.Services.AddControllersWithViews();

// ✅ 3. Configurar Antiforgery para desarrollo local (HTTP en localhost)
builder.Services.AddAntiforgery(options =>
{
	options.Cookie.Name = "AntiforgeryCookie";
	options.Cookie.HttpOnly = true;
	options.Cookie.SameSite = SameSiteMode.Strict;
	options.Cookie.SecurePolicy = CookieSecurePolicy.None; // ⚠️ SOLO PARA localhost sin HTTPS
});

var app = builder.Build();

// 4. Aplicar migraciones (si fuera necesario)
// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     var context = services.GetRequiredService<ApplicationDbContext>();
//     context.Database.Migrate();
// }

// 5. Configuración del pipeline HTTP
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}
else
{
	app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection(); // Redirige a HTTPS si está activado
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ⚠️ Si usaras autenticación en el futuro, iría también app.UseAuthentication();

// 6. Ruta por defecto
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
