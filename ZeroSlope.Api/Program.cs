var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();

var settings = builder.Configuration.Get<ContainerOptions>();
builder.Services.AddSingleton<ContainerOptions>(settings);
new ContainerInstaller(settings).Install(builder.Services);

builder.Services.AddSingleton<ITokenService>(new TokenService());
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = settings.Token.Issuer,
        ValidAudience = settings.Token.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Token.Secret))
    };
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options => options.AddPolicy("allowAny", o => o.AllowAnyOrigin()));

builder.Services.AddSwaggerGen(swagger =>
{
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,
            },
            new List<string>()
          }
        });
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();

app.useHealthRoutes();
app.useAuthRoutes();
app.useSampleRoutes();

app.UseCors(x => x.AllowAnyOrigin());

app.UseMiddleware<HandledResultMiddleware>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.Run();