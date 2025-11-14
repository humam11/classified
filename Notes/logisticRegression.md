https://chatgpt.com/c/68e817f5-34d8-832d-b996-35e200dfe2ac

| Step | Description                  | Example Output           |
| ---- | ---------------------------- | ------------------------ |
| 1    | Tokenize & clean text        | “employee, looking, job” |
| 2    | Compute TF                   | [1/3, 1/3, 1/3]          |
| 3    | Compute IDF                  | [2.48, 1.8, 0.9]         |
| 4    | TF-IDF                       | [0.83, 0.6, 0.3]         |
| 5    | Compute weighted scores (zᵢ) | Job = 1.974              |
| 6    | Apply softmax                | [0.108, 0.108, 0.782]    |
| 7    | Pick argmax                  | **Job**                  |
