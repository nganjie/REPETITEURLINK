using REPETITEURLINK;
using System;
using System.Collections.Generic;
using System.Text;

namespace REPETITEURLINK.Entities.Repositories;

public class BaseRepository
{
    protected readonly IRepository _repository;
    protected readonly AppConfiguration? _bcaConfig;

    public BaseRepository(IRepository repository, AppConfiguration? bcaConfig = null)
    {
        _repository = repository;
        _bcaConfig = bcaConfig;
    }
}
