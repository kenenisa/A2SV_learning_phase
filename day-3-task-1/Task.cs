class Task
{
    public string Name;
    public string Description;
    public TaskCategories Category;
    public bool IsCompleted;
    public override string ToString()
    {
        return $"{Name}-{Description}-{Category}-{IsCompleted}";
    }

}