# Ads & CV Posting Workflow

## Note: Ads & CV Posting Workflow

### 1. Ads Posting
1. User drills down the category tree to the lowest‐level category.
2. Front end loads the form fields for that leaf category (see the MongoDB example document).
3. User completes the form and clicks **Post**.
4. **Visibility rule:**
   - `status` must be `active` for the ad to be shown to end users.

### 2. CV Posting
1. User drills down starting from the top‐level category **ابحث عن موظف** to the lowest‐level category.
2. Front end loads the same form‐fields mechanism as for ads.
3. User fills in all CV fields, including `job_search_status`.
4. **job_search_status** (حالة البحث عن عمل):
   - `0` = يبحث عن عمل
   - `1` = موظف ويبحث عن عمل جديد
   - `2` = غير يبحث عن عمل
5. **Visibility rule:**
   - Only CVs with `job_search_status` = `0` or `1` will be visible to the audience. CVs marked `2` are not shown.

### 3. CV Status Management Rules
- **When CV is created/updated:**
  - If `job_search_status` = `0` or `1` → `status` = `"active"` (CV is visible)
  - If `job_search_status` = `2` → `status` = `"archived"` (CV is hidden)
- **When CV is deleted:**
  - `status` = `"deleted"` (CV is permanently hidden)