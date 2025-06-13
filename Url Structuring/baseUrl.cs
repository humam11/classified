string version = pm.environment.get("version");
string langCode = pm.environment.get("langCode");

// Create the combined prefix.
string prefix = $"www.domain.com/{version}/{langCode}";
