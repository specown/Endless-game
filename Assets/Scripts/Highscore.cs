 
 [System.Serializable]
 public class Highscore
 {
    public string name;
    public double score;
 
    public Highscore(string name, double score) {
        this.name = name;
        this.score = score;
    }
 }