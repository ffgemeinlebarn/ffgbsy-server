using ffg.BSY.Contracts;
using ffg.BSY.Data.Repositories;

namespace ffg.BSY.Data;

public class RepositoryContext
{
    private readonly DataContext context;
    private IAufnehmerRepository aufnehmer = null!;
    private IDruckerRepository drucker = null!;
    private ITischkategorienRepository tischkategorien = null!;
    private ITischeRepository tische = null!;

    public IAufnehmerRepository Aufnehmer
    { get => this.aufnehmer is null ? new AufnehmerRepository(this.context) : this.aufnehmer; }

    public IDruckerRepository Drucker
    { get => this.drucker is null ? new DruckerRepository(this.context) : this.drucker; }

    public ITischkategorienRepository Tischkategorien
    { get => this.tischkategorien is null ? new TischkategorienRepository(this.context) : this.tischkategorien; }

    public ITischeRepository Tische
    { get => this.tische is null ? new TischeRepository(this.context) : this.tische; }

    public RepositoryContext(DataContext context)
    {
        this.context = context;
    }

    public void Save()
    {
        this.context.SaveChanges();
    }
}
