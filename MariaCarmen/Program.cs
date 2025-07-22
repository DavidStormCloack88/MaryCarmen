using MariaCarmen.Aplicacion.Servicio;
using MariaCarmen.Aplicacion.ServicioImpl;
using MariaCarmen.Dominio.Modelos.Abstracciones;
using MariaCarmen.Infraestructura.AccesoDatos;
using MariaCarmen.Infraestructura.AccesoDatos.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//1.- Leer la variable de conexion a la BD del appsettings
var conexiondb = builder.Configuration.GetConnectionString("ConexionDBMaryCarmen");

//2.- configuar el bdContext con la conexion almacenada
builder.Services.AddDbContext<MaryCarmenDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDBMaryCarmen")));

//3.- configurar los servicios 
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorioImpl>();
builder.Services.AddScoped<ICategoriaServicio, CategoriaServicioImpl>();
builder.Services.AddScoped<IProductoServicio, CProductosServicioImpl>();
builder.Services.AddScoped<IRolesRepositorio, RolesRepositorioImpl>();
builder.Services.AddScoped<IRolesServicio, RolesServicioImpl>();
builder.Services.AddScoped<ISucursalesRepositorio, SucursalRepositorioImpl>();
builder.Services.AddScoped<ISucursalesServicio, SucursalesServicioImpl>();
builder.Services.AddScoped<IVentaRepositorio, VentaRepositorioImpl>();
builder.Services.AddScoped<IVentaServicio, VentaServicioImpl>();
builder.Services.AddScoped<IUsuariosRepositorio, UsuarioRepositorioImpl>();
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicioImpl>();
builder.Services.AddScoped<ITrasladoInternoRepositorio, TrasladoInternoRepositorioImpl>();
builder.Services.AddScoped<ITrasladoInternoServicio,  TrasladoInternoServicioImpl>();
builder.Services.AddScoped<IDetalleVentasRepositorio, DetalleVentaRepositorioImpl>();
builder.Services.AddScoped<IDetalleVentaServicio, DetalleVentaServicioImpl>();






// Habilitar CORS (opcional)
builder.Services.AddCors();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
