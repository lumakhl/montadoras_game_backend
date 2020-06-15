public class Resposta
{
    public long Id { get; set; }
    public string Descricao { get; set; }
    public bool EhCerta { get; set; }
    
    public Pergunta Pergunta {get; set;}
   // public int PerguntaId {get; set;}

}