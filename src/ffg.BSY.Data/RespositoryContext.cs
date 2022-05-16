using ffg.BSY.Data.Contracts;
using ffg.BSY.Data.Repositories;

namespace ffg.BSY.Data;

public class RepositoryContext
{
    private readonly DataContext context;
    private IAufnehmerRepository aufnehmer;

    public IAufnehmerRepository Aufnehmer
    {
        get
        {
            if (this.aufnehmer == null)
            {
                this.aufnehmer = new AufnehmerRepository(this.context);
            }
            return this.aufnehmer;
        }
    }

    public RepositoryContext(DataContext context) => this.context = context;

    public void Save()
    {
        this.context.SaveChanges();
    }
}