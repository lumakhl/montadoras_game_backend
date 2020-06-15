using Microsoft.EntityFrameworkCore;
using System.Collections.Generic; 
using Microsoft.Extensions.DependencyInjection;
using MontadorasGameApi.Models;

public class DataGenerator
{
    public static void Initialize(System.IServiceProvider serviceProvider)
    {
        using (var context = new MontadorasGameContext(
            serviceProvider.GetRequiredService<DbContextOptions<MontadorasGameContext>>()))
        {
            List<Resposta> respostas1 = new List<Resposta>();
            List<Resposta> respostas2 = new List<Resposta>();
            List<Resposta> respostas3 = new List<Resposta>();
            List<Resposta> respostas4 = new List<Resposta>();
            List<Resposta> respostas5 = new List<Resposta>();

            respostas1.AddRange(new List<Resposta>() {
                new Resposta { Id =1, Descricao = "Inglaterra", EhCerta = false },
                new Resposta { Id =2, Descricao = "USA", EhCerta = false },
                new Resposta { Id =3, Descricao = "Alemanha", EhCerta = true },
                new Resposta { Id =4, Descricao = "Japão", EhCerta = false },
            }); 

            respostas2.AddRange(new List<Resposta>() {
                new Resposta { Id =5, Descricao = "Inglaterra", EhCerta = false },
                new Resposta { Id =6, Descricao = "USA", EhCerta = false },
                new Resposta { Id =7, Descricao = "Alemanha", EhCerta = false },
                new Resposta { Id =8, Descricao = "Japão", EhCerta = true },
            }); 

            respostas3.AddRange(new List<Resposta>() {
                new Resposta { Id =9, Descricao = "Inglaterra", EhCerta = true },
                new Resposta { Id =10, Descricao = "USA", EhCerta = false },
                new Resposta { Id =11, Descricao = "Alemanha", EhCerta = false },
                new Resposta { Id =12, Descricao = "Japão", EhCerta = false },
            }); 

            respostas4.AddRange(new List<Resposta>() {
                new Resposta { Id =13, Descricao = "Inglaterra", EhCerta = false },
                new Resposta { Id =14, Descricao = "USA", EhCerta = true },
                new Resposta { Id =15, Descricao = "Alemanha", EhCerta = false },
                new Resposta { Id =16, Descricao = "Japão", EhCerta = false },
            }); 

            respostas5.AddRange(new List<Resposta>() {
                new Resposta { Id =17, Descricao = "Inglaterra", EhCerta = true },
                new Resposta { Id =18, Descricao = "USA", EhCerta = false },
                new Resposta { Id =19, Descricao = "Alemanha", EhCerta = false },
                new Resposta { Id =20, Descricao = "Japão", EhCerta = false },
            }); 

            context.Pergunta.AddRange(
                new Pergunta { Id = 1, Descricao = "Qual o país de origem da BMW?", Respostas = respostas1 },
                new Pergunta { Id = 2, Descricao = "Qual o país de origem da Toyota?", Respostas = respostas2 },
                new Pergunta { Id = 3, Descricao = "Qual o país de origem da Mini?", Respostas = respostas3 },
                new Pergunta { Id = 4, Descricao = "Qual o país de origem da General Motors?", Respostas = respostas4 },
                new Pergunta { Id = 5, Descricao = "Qual o país de origem da Rolls-Royce?", Respostas = respostas5 }            
            );

            context.SaveChanges();
        }
    }

}