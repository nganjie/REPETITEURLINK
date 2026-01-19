using REPETITEURLINK.Entities.Data;

namespace REPETITEURLINK;

public static class RepetitionSeedData
{
    public static List<DirectoryItem> DirectoryItems = new List<DirectoryItem>();
    public static List<Subject> Subjects = new List<Subject>();
    public static List<User> users = new List<User>();
    public static readonly Guid CameroonId = Guid.Parse("8ff12163-8fdc-4657-80d0-c510a27b54df");
    public static readonly Guid CameroonCurrencyId = Guid.Parse("5330d345-8ecf-4a94-8de2-742d448c52fb");

    // ======================
    // CITIES
    // ======================
    public static readonly Guid YaoundeId = Guid.Parse("753e4bf2-f965-4f7c-b2ff-64b34cbe7fbb");
    public static readonly Guid DoualaId = Guid.Parse("d3873ec8-cb6b-482e-9ba3-90facc2b3fb1");
    public static readonly Guid BafoussamId = Guid.Parse("ca10411d-8f52-4ad8-aeba-1e1bd634fa61");
    public static readonly Guid BamendaId = Guid.Parse("f5b9bf9f-c280-4301-99b7-4ac73cc9b167");
    public static readonly Guid GarouaId = Guid.Parse("004a71f4-0612-4926-b36c-1f845d387e61");
    public static readonly DateTime now = (new DateTime(2025, 1, 17)).ToUniversalTime();

    // =========================
    // FRANCOPHONE – SECONDARY
    // =========================
    public static readonly Guid Id6E = Guid.Parse("c9f478d1-903a-4ee6-84ed-92608e293c47");
    public static readonly Guid Id5E = Guid.Parse("4ccc720d-cb3f-4915-a268-43e6e699d3b2");
    public static readonly Guid Id4E = Guid.Parse("2b4d8461-240b-4e1b-84f4-f7148b4da0d3");
    public static readonly Guid Id3E = Guid.Parse("28a67a7d-03ef-40df-b91b-3ce45a6bcfb1");
    public static readonly Guid IdSECONDE = Guid.Parse("ac3fdc3d-beb7-4806-9413-384a32c21e1a");
    public static readonly Guid IdPREMIERE = Guid.Parse("18972a21-ee93-45fe-b337-8e1ec2a7657b");
    public static readonly Guid IdTERMINALE = Guid.Parse("c0a60a47-3d81-4a8a-8582-267410320fb7");

    // =========================
    // SUPERIOR
    // =========================
    public static readonly Guid IdL1 = Guid.Parse("c2e86c42-1eb7-4cb3-9247-632ccc7960bb");
    public static readonly Guid IdL2 = Guid.Parse("ac2e4a38-4d9d-460d-ab37-f4b4ea14df5e");
    public static readonly Guid IdL3 = Guid.Parse("b8a19c5a-6a48-4143-b391-313fb95d89dd");
    public static readonly Guid IdM1 = Guid.Parse("262aef51-3b3e-4f52-8bb2-f912b288b7c0");
    public static readonly Guid IdM2 = Guid.Parse("399f1a29-ab8f-409a-abd8-b936c3f66f29");
    // =========================
    // ANGLOPHONE – PRIMARY
    // =========================
    public static readonly Guid IdCLASS_1 = Guid.Parse("6896174a-96f1-456e-83a5-de5861d9123b");
    public static readonly Guid IdCLASS_2 = Guid.Parse("877636e7-73a4-498a-b12a-96d78424d123");
    public static readonly Guid IdCLASS_3 = Guid.Parse("6b4435c7-ba35-4ed4-9281-4e10092b3cfc");
    public static readonly Guid IdCLASS_4 = Guid.Parse("350641cf-22c4-45b6-a222-8ce2b93a1770");
    public static readonly Guid IdCLASS_5 = Guid.Parse("278b6e0a-f892-43e5-803e-5322c78620f3");
    public static readonly Guid IdCLASS_6 = Guid.Parse("e9e7e694-63df-4e16-bb30-fc3f4437a30c");

    // =========================
    // ANGLOPHONE – SECONDARY
    // =========================
    public static readonly Guid IdFORM_1 = Guid.Parse("025e1c40-4593-47de-bc4e-b389c91c45fb");
    public static readonly Guid IdFORM_2 = Guid.Parse("64478a7c-f553-4409-9b20-aa5eda6010bd");
    public static readonly Guid IdFORM_3 = Guid.Parse("8092a7e1-6773-4ead-9204-15c653bbb55a");
    public static readonly Guid IdFORM_4 = Guid.Parse("22398de3-c316-41ff-a09d-41f15a856ba4");
    public static readonly Guid IdFORM_5 = Guid.Parse("9d682bb1-dcb5-4ac6-be8f-5403e3880971");
    public static readonly Guid IdLOWER_SIXTH = Guid.Parse("b77ca2cc-fb1f-4795-a722-c2fb9ccef8aa");
    public static readonly Guid IdUPPER_SIXTH = Guid.Parse("1d54025c-b1d8-4baf-8aac-0d37a14d4e52");

    // =========================
    // CONSTANTES STATIQUES POUR LES IDs DES SUJETS
    // =========================
    public static readonly Guid IdAnglais = Guid.Parse("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d");
    public static readonly Guid IdFrancais = Guid.Parse("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e");
    public static readonly Guid IdInformatique = Guid.Parse("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f");
    public static readonly Guid IdMathematiques = Guid.Parse("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f8a");
    public static readonly Guid IdPCT = Guid.Parse("e5f6a7b8-c9d0-4e1f-2a3b-4c5d6e7f8a9b");
    public static readonly Guid IdSVT = Guid.Parse("f6a7b8c9-d0e1-4f2a-3b4c-5d6e7f8a9b0c");
    public static readonly Guid IdPhysique = Guid.Parse("a7b8c9d0-e1f2-4a3b-4c5d-6e7f8a9b0c1d");
    public static readonly Guid IdChimie = Guid.Parse("b8c9d0e1-f2a3-4b4c-5d6e-7f8a9b0c1d2e");

    static RepetitionSeedData()
    {
        allDirectory();
    }
    public static void allDirectory()
    {
        DirectoryCountrySeed();
        DirectoryCurrencySeed();
        DirectoryCity();
        DirectoryNeighborhood();
        DirectoryLevel();
        SeedSubjects();
        UserSeed();
    }
    public static void UserSeed()
    {
        users.AddRange(new User[] {
            new User
            {
                Id=Guid.Parse("c211feb2-e860-473e-8165-8bc7994a5b3c"),
                FirstName="NGANJIE NZATSI",
                LastName="THEDE REINEL",
                Email="nganjienzatsi@gmail.com",
                Sexe=Gender.Male,
                Password=BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                PhoneNumber="679015958",
                CityId=DoualaId,
                Role=UserRoles.SuperAdmin,
                ParentSubjectType=UserSubjectType.None,
                CreatedAt=now,
                IsDeleted=false,

            }
        });
    }
    public static void DirectoryCountrySeed()
    {
        DirectoryItems.AddRange(new DirectoryItem[] {
            new DirectoryItem
            {
                Id = CameroonId,
                Kind = DirectoryKinds.Country,
                Value = "CM",
                DisplayName = "Cameroun",
                CreatedAt = now,
                IsDeleted=false,
            },
        });
    }
    public static void DirectoryCurrencySeed()
    {
        DirectoryItems.AddRange(new DirectoryItem[] {
            new DirectoryItem
            {
                Id = CameroonCurrencyId,
                DisplayName="FCFA",
                Kind=DirectoryKinds.Currency,
                Value="XAF",
                Symbol="XAF",
                IsDeleted=false,
            },
        });
    }
    public static void DirectoryCity()
    {
        DirectoryItems.AddRange(new DirectoryItem[] {
             new DirectoryItem
            {
                Id = YaoundeId,
                Kind = DirectoryKinds.City,
                Value = "YAOUNDE",
                DisplayName = "Yaoundé",
                CountryId = CameroonId,
                CreatedAt = now,
                IsDeleted=false,
            },
            new DirectoryItem
            {
                Id = DoualaId,
                Kind = DirectoryKinds.City,
                Value = "DOUALA",
                DisplayName = "Douala",
                CountryId = CameroonId,
                CreatedAt = now,
                IsDeleted=false,
            },
            new DirectoryItem
            {
                Id = BafoussamId,
                Kind = DirectoryKinds.City,
                Value = "BAFOUSSAM",
                DisplayName = "Bafoussam",
                CountryId = CameroonId,
                CreatedAt = now,
                IsDeleted=false,
            },
            new DirectoryItem
            {
                Id = BamendaId,
                Kind = DirectoryKinds.City,
                Value = "BAMENDA",
                DisplayName = "Bamenda",
                CountryId = CameroonId,
                CreatedAt = now,
                IsDeleted=false,
            },
            new DirectoryItem
            {
                Id = GarouaId,
                Kind = DirectoryKinds.City,
                Value = "GAROUA",
                DisplayName = "Garoua",
                CountryId = CameroonId,
                CreatedAt = now,
                IsDeleted=false,
            },
        });
            
            }

    public static void DirectoryNeighborhood()
    {
        DirectoryItems.AddRange(new DirectoryItem[]
        {
            Neighborhood("a8ac01dd-40ea-4b8a-b6a0-bb66f4c88275","BASTOS", "Bastos", YaoundeId, now),
            Neighborhood("ca21bd6d-3506-4951-9c5d-192aec6356f9","BIYEM_ASSI", "Biyem-Assi", YaoundeId, now),
            Neighborhood("75564c79-4adf-4c72-a09e-670d4ce331fd","MOKOLO", "Mokolo", YaoundeId, now),
            Neighborhood("73ce5015-cba6-4ac1-b592-ee6cf853f2ea","NKOLOBISSON", "Nkolbisson", YaoundeId, now),

            // ======================
            // NEIGHBORHOODS – DOUALA
            // ======================
            Neighborhood("96caf3d2-bfc6-4b96-a76f-83dfb1bca49f","AKWA", "Akwa", DoualaId, now),
            Neighborhood("89574e90-4a05-45f9-9a40-dd7b201c35f4","BONAPRISO", "Bonapriso", DoualaId, now),
            Neighborhood("5ae2b031-492d-4363-b10d-aa50acafaa52","BONABERI", "Bonabéri", DoualaId, now),
            Neighborhood("d624e25c-40cf-408a-9f2c-7125a1d01079","NEW_BELL", "New Bell", DoualaId, now),

            // ======================
            // NEIGHBORHOODS – BAFOUSSAM
            // ======================
            Neighborhood("595f9ff8-953b-420f-b51c-efc964ed4843","BANENGO", "Banengo", BafoussamId, now),
            Neighborhood("92585578-3805-49c7-9263-3bbd5d8a606b","DJELENG", "Djeleng", BafoussamId, now),

            // ======================
            // NEIGHBORHOODS – BAMENDA
            // ======================
            Neighborhood("4364d167-79f2-4a03-89d2-c09ea5c8ffbe","MANKON", "Mankon", BamendaId, now),
            Neighborhood("8f62af8c-74c2-417c-bd73-17ead0a34c44","NKWEN", "Nkwen", BamendaId, now),

            // ======================
            // NEIGHBORHOODS – GAROUA
            // ======================
            Neighborhood("15470d97-c076-4ab3-82ae-c4a6d06c2188","PADAMA", "Padama", GarouaId, now),
            Neighborhood("b1ae7aa2-c80c-4aee-ba64-434c2d1932a9","BENUE", "Bénoué", GarouaId, now),
        });
    }
    private static DirectoryItem Neighborhood(string id,string value, string name, Guid cityId, DateTime now)
    {
        return new DirectoryItem
        {
            Id = Guid.Parse(id),
            Kind = DirectoryKinds.Neighborhood,
            Value = value,
            DisplayName = name,
            CityId = cityId,
            CreatedAt = now,
            IsDeleted = false,
        };
    }

    public static void DirectoryLevel()
    {
        DirectoryItems.AddRange(new DirectoryItem[] {
            Level(Id6E, "6E", "Sixième", now),
Level(Id5E, "5E", "Cinquième", now),
Level(Id4E, "4E", "Quatrième", now),
Level(Id3E, "3E", "Troisième", now),
Level(IdSECONDE, "SECONDE", "Seconde", now),
Level(IdPREMIERE, "PREMIERE", "Première", now),
Level(IdTERMINALE, "TERMINALE", "Terminale", now),

// =========================
// SUPERIOR
// =========================
Level(IdL1, "L1", "Licence 1", now),
Level(IdL2, "L2", "Licence 2", now),
Level(IdL3, "L3", "Licence 3", now),
Level(IdM1, "M1", "Master 1", now),
Level(IdM2, "M2", "Master 2", now),

// =========================
// ANGLOPHONE – PRIMARY
// =========================
Level(IdCLASS_1, "CLASS_1", "Class 1", now),
Level(IdCLASS_2, "CLASS_2", "Class 2", now),
Level(IdCLASS_3, "CLASS_3", "Class 3", now),
Level(IdCLASS_4, "CLASS_4", "Class 4", now),
Level(IdCLASS_5, "CLASS_5", "Class 5", now),
Level(IdCLASS_6, "CLASS_6", "Class 6", now),

// =========================
// ANGLOPHONE – SECONDARY
// =========================
Level(IdFORM_1, "FORM_1", "Form 1", now),
Level(IdFORM_2, "FORM_2", "Form 2", now),
Level(IdFORM_3, "FORM_3", "Form 3", now),
Level(IdFORM_4, "FORM_4", "Form 4", now),
Level(IdFORM_5, "FORM_5", "Form 5", now),
Level(IdLOWER_SIXTH, "LOWER_SIXTH", "Lower Sixth", now),
Level(IdUPPER_SIXTH, "UPPER_SIXTH", "Upper Sixth", now),
        } );
    }
    private static DirectoryItem Level(Guid id,string value, string displayName, DateTime now)
    {
        return new DirectoryItem
        {
            Id = id,
            Kind = DirectoryKinds.SchoolClassLevel,
            Value = value,
            DisplayName = displayName,
            CreatedAt = now,
            IsDeleted = false
        };
    }
    public static Subject subjectC(Guid id,string name, string displayName, decimal averageHourlyRate)
    {
        return new Subject
        {
            Id = id,
            Name = name,
            DisplayName = displayName,
            AverageHourlyRate = averageHourlyRate,
            CreatedAt = now,
            UpdatedAt = null,
            IsDeleted = false,
            DeletedOn = null
        };
    }

    private static void SeedSubjects()
    {
        Subjects.AddRange(new Subject[] {
            subjectC(IdAnglais, "Anglais", "Anglais", 2500),
subjectC(IdFrancais, "Francais", "Français", 2500),
subjectC(IdInformatique, "Informatique", "Informatique", 3000),
subjectC(IdMathematiques, "Mathematiques", "Mathématiques", 2800),
subjectC(IdPCT, "PCT", "Physique, Chimie et Technologie", 2700),
subjectC(IdSVT, "SVT", "SCIENCE DE LA VIE ET DE LA TERRE", 2600),
subjectC(IdPhysique, "Physique", "Physique", 2750),
subjectC(IdChimie, "Chimie", "Chimie", 2750),
        });
    }
}