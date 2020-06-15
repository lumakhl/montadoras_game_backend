using System.Collections.Generic; 
public class Pergunta
{
    public long Id { get; set; }

    public string Descricao { get; set; }

    public List<Resposta> Respostas {get; set;}

}