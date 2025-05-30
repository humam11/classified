## Note: Ads & CV Posting Workflow

### 1. Ads Posting
1. User drills down the category tree to the lowest‐level category.
2. Front end loads the form fields for that leaf category (see the MongoDB example document).
3. User completes the form and clicks **Post**.
4. **Visibility rule:**  
   - `isActive` must be `true` (or `1`) for the ad to be shown to end users.

### 2. CV Posting
1. User drills down starting from the top‐level category **ابحث عن موظف** to the lowest‐level category.
2. Front end loads the same form‐fields mechanism as for ads.
3. User fills in all CV fields, including `job_search_status`.
4. **job_search_status** (حالة البحث عن عمل):
   - `1` = يبحث عن عمل  
   - `2` = موظف ويبحث عن عمل جديد  
   - `3` = غير يبحث عن عمل  
5. **Visibility rule:**  
   - Only CVs with `job_search_status` = `1` or `2` will be visible to the audience. CVs marked `3` are not shown.
