using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;

public class DatabaseService : IDatabaseService
{
    public void Initialize()
    {
        CreateCollection("User");
        SetCollectionPrimeryKey("User", "_userId");

        CreateCollection("Error");
        SetCollectionPrimeryKey("Error", "_errorDescription");

        CreateCollection("Patient");
        SetCollectionPrimeryKey("Patient", "_identityNumber");

        InitializeUserCollection();
        InitializeErrorCollection();
        InitializePatientCollection();
    }

    private void InitializeErrorCollection()
    {
        var errorService = new ErrorService();

        var error = Error.ErrorType.PasswordIsIncorrect;
        errorService.AddError(error);

        error = Error.ErrorType.UserIsNotExist;
        errorService.AddError(error);

        error = Error.ErrorType.UserIsAlreadyExist;
        errorService.AddError(error);
    }

    private void InitializeUserCollection()
    {
        var userService = new UserService();

        var user = new User("Karin", "123", "Karin", "B", "karin@gmail.com", "K", DateTime.Today, true, true);
        userService.AddUser(user);

        user = new User("Sari", "123", "Sari", "Q", "sari@gmail.com", "K", DateTime.Today, true, true);
        userService.AddUser(user);
    }

    private void InitializePatientCollection()
    {
        var patientService = new PatientService();
        Assignment[] t = new Assignment[1];
        t[0]=new Assignment("Finish Project", "content", false);

        var patient = new Patient("123", "Karin", "B", "karin@gmail.com", "K", DateTime.Today, t);
        patientService.AddPatient(patient);

        patient = new Patient("1233", "Sari", "Q", "sari@gmail.com", "K", DateTime.Today, t);
        patientService.AddPatient(patient);
    }

    private MongoDatabase GetDatabase()
    {
        MongoClient client = new MongoClient();
        var server = client.GetServer();
        var database = server.GetDatabase("ELI5");
        return database;
    }

    private void CreateCollection(string collectionName)
    {
        var database = GetDatabase();
        var collection = database.CreateCollection(collectionName);
    }

    public MongoCollection GetCollection(string collectionName)
    {
        var database = GetDatabase();
        var collection = database.GetCollection(collectionName);
        return collection;
    }

    private void SetCollectionPrimeryKey(string collectionName, string primeryKeyName)
    {
        var collection = GetCollection(collectionName);
        collection.EnsureIndex(new IndexKeysBuilder().Ascending(primeryKeyName), IndexOptions.SetUnique(true));
    }

}