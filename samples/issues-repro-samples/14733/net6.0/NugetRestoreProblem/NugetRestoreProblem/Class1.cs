namespace NugetRestoreProblem
{
  // All the code in this file is included in all platforms.
  public class Class1
  {
    public string GetUserPreference(string preferenceKey)
    {
      return Preferences.Get(preferenceKey,default(string));
    }
  }
}