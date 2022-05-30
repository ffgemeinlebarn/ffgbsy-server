using ffg.BSY.Contracts;
using ffg.BSY.Data.Repositories;

namespace ffg.BSY.Data;

public class RepositoryContext
{
    private readonly DataContext context;
    private IAufnehmerRepository aufnehmer = null!;
    private IDruckerRepository drucker = null!;

    public IAufnehmerRepository Aufnehmer
    { get => this.aufnehmer is null ? new AufnehmerRepository(this.context) : this.aufnehmer; }

    public IDruckerRepository Drucker
    { get => this.drucker is null ? new DruckerRepository(this.context) : this.drucker; }

    public RepositoryContext(DataContext context)
    {
        this.context = context;
    }

    public void Save()
    {
        this.context.SaveChanges();
    }
}
