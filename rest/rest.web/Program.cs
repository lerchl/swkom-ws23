using Rest.Logic.Service;
using Rest.Dal;
using Rest.Logic.Service;
using Rest.Logging;

namespace Rest.Web {
    public class RestApplication {
        private static readonly IPaperlessLogger _logger = PaperlessLoggerFactory.GetLogger();
        public static void Main(string[] args) {
            using (var context = new PostgreContext()) {
                try {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                }
                catch (Exception e) {
                    _logger.Fatal(e.Message);
                }
            }

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options => {
                options.AddDefaultPolicy(policy => {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Repositories
            builder.Services.AddSingleton<IDocumentRepository, DbDocumentRepository>();
            builder.Services.AddSingleton<IDocumentTypeRepository, DbDocumentTypeRepository>();
            builder.Services.AddSingleton<ICorrespondentRepository, DbCorrespondentRepository>();
            builder.Services.AddSingleton<IDocTagRepository, DbDocTagRepository>();

            // Services
            builder.Services.AddSingleton<IDocumentService, DocumentService>();
            builder.Services.AddSingleton<IDocumentTypeService, DocumentTypeService>();
            builder.Services.AddSingleton<ICorrespondentService, CorrespondentService>();
            builder.Services.AddSingleton<IDocTagService, DocTagService>();

            builder.Services.AddSingleton<IRabbitMqService, RabbitMqService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseAuthorization();

            app.MapControllers();

            app.UseHttpLogging();

            app.Run();
        }
    }
}
