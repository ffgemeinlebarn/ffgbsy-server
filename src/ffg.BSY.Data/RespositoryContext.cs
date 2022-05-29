using ffg.BSY.Data.Contracts;
using ffg.BSY.Data.Repositories;

namespace ffg.BSY.Data;

public class RepositoryContext
{
    private readonly DataContext context;
    private IAufnehmerRepository aufnehmer = null!;

    public IAufnehmerRepository Aufnehmer
    {
        get => this.aufnehmer is null ? new AufnehmerRepository(this.context) : this.aufnehmer;
    }

    public RepositoryContext(DataContext context)
    {
        this.context = context;
    }

    public void Save()
    {
        this.context.SaveChanges();
    }
}