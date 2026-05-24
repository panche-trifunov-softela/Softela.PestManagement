import anthropic
import os

SYSTEM_PROMPT = """You are reviewing pull requests for Softela.PestManagement, a .NET 10 clean architecture application.

Key conventions to enforce:
- All PostgreSQL identifiers must be snake_case (tables, columns, functions, constraints, indexes)
- Dapper repositories use CommandType.Text — writes via SELECT upsert_x(...), reads via SELECT * FROM get_x(...), deletes via SELECT delete_x(...)
- Upsert SQL must be functions returning INT, not stored procedures
- CQRS: each Command/Query folder must have Request, Response, Handler, and a static Mapper class
- Command handlers must follow the UnitOfWork pattern: BeginTransactionAsync → try { ... CommitAsync } catch { RollbackAsync; throw }
- Domain events must be published via IOutboxRepository.InsertAsync inside the transaction, never outside
- All tenant-scoped handlers must inject ITenantContext and use TenantId/UserId for scoping and audit fields
- No hardcoded config values — everything through appsettings.json / IConfiguration
- Soft deletes on all tenant-scoped entities (IsDeleted flag)

Provide a concise review structured as:

### Issues
Blocking problems that must be fixed before merging.

### Suggestions
Non-blocking improvements worth considering.

### Positives
What was done well.

Be specific — reference file names and line numbers where relevant. If there is nothing to report in a section, write "None."
"""

def main():
    client = anthropic.Anthropic(api_key=os.environ["ANTHROPIC_API_KEY"])

    with open("pr_diff.txt", "r", encoding="utf-8") as f:
        diff = f.read()

    if len(diff) > 120_000:
        diff = diff[:120_000] + "\n\n[... diff truncated due to size ...]"

    pr_title = os.environ.get("PR_TITLE", "")
    pr_body = os.environ.get("PR_BODY", "")

    message = client.messages.create(
        model="claude-opus-4-7",
        max_tokens=2048,
        system=SYSTEM_PROMPT,
        messages=[
            {
                "role": "user",
                "content": (
                    f"Please review this pull request.\n\n"
                    f"**Title:** {pr_title}\n\n"
                    f"**Description:** {pr_body or 'No description provided.'}\n\n"
                    f"**Diff:**\n```diff\n{diff}\n```"
                ),
            }
        ],
    )

    review_text = f"## Claude PR Review\n\n{message.content[0].text}"

    with open("review_output.md", "w", encoding="utf-8") as f:
        f.write(review_text)

if __name__ == "__main__":
    main()
