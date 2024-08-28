## Breaking Changes Notice

UGemini v2.0.0 contains many breaking changes. To update your code to use UGemini 2.0.0,
refer to the following list and table of changes:

### General Changes
- `EnumExtensions` is now `GeminiContentTypeExtensions`.
- All code previously marked as "deprecated" has been removed.

### Namespace Changes

| Class                                 | Old Namespace                             | New Namespace                                                             |
|-----------                            |---------------                            |---------------                                                            |
| `GeminiContent`                       | `Uralstech.UGemini`                       | `Uralstech.UGemini.Models.Content`                                        |
| `GeminiContentBlob`                   | `Uralstech.UGemini`                       | `Uralstech.UGemini.Models.Content`                                        |
| `GeminiContentPart`                   | `Uralstech.UGemini`                       | `Uralstech.UGemini.Models.Content`                                        |
| `GeminiFileData`                      | `Uralstech.UGemini`                       | `Uralstech.UGemini.Models.Content`                                        |
| `GeminiRole`                          | `Uralstech.UGemini`                       | `Uralstech.UGemini.Models.Content`                                        |
| `UnityExtensions`                     | `Uralstech.UGemini`                       | `Uralstech.UGemini.Models.Content`                                        |
| `GeminiAttributionSourceId`           | `Uralstech.UGemini.Chat`                  | `Uralstech.UGemini.Models.Content.Attribution`                            |
| `GeminiGroundingAttribution`          | `Uralstech.UGemini.Chat`                  | `Uralstech.UGemini.Models.Content.Attribution`                            |
| `GeminiGroundingPassageId`            | `Uralstech.UGemini.Chat`                  | `Uralstech.UGemini.Models.Content.Attribution`                            |
| `GeminiSemanticRetrieverChunk`        | `Uralstech.UGemini.Chat`                  | `Uralstech.UGemini.Models.Content.Attribution`                            |
| `GeminiCitationMetadata`              | `Uralstech.UGemini.Chat`                  | `Uralstech.UGemini.Models.Content.Citation`                               |
| `GeminiCitationSource`                | `Uralstech.UGemini.Chat`                  | `Uralstech.UGemini.Models.Content.Citation`                               |
| `GeminiTokenCountRequest`             | `Uralstech.UGemini.TokenCounting`         | `Uralstech.UGemini.Models.CountTokens`                                    |
| `GeminiTokenCountResponse`            | `Uralstech.UGemini.TokenCounting`         | `Uralstech.UGemini.Models.CountTokens`                                    |
| `GeminiBatchEmbedContentRequest`      | `Uralstech.UGemini.Embedding`             | `Uralstech.UGemini.Models.Embedding`                                      |
| `GeminiBatchEmbedContentResponse`     | `Uralstech.UGemini.Embedding`             | `Uralstech.UGemini.Models.Embedding`                                      |
| `GeminiContentEmbedding`              | `Uralstech.UGemini.Embedding`             | `Uralstech.UGemini.Models.Embedding`                                      |
| `GeminiEmbedContentRequest`           | `Uralstech.UGemini.Embedding`             | `Uralstech.UGemini.Models.Embedding`                                      |
| `GeminiEmbedContentResponse`          | `Uralstech.UGemini.Embedding`             | `Uralstech.UGemini.Models.Embedding`                                      |
| `GeminiEmbedTaskType`                 | `Uralstech.UGemini.Embedding`             | `Uralstech.UGemini.Models.Embedding`                                      |
| `GeminiGenerationConfiguration`       | `Uralstech.UGemini.Chat`                  | `Uralstech.UGemini.Models.Generation`                                     |
| `GeminiResponseType`                  | `Uralstech.UGemini.Chat`                  | `Uralstech.UGemini.Models.Generation`                                     |
| `GeminiCandidate`                     | `Uralstech.UGemini.Chat`                  | `Uralstech.UGemini.Models.Generation.Candidate`                           |
| `GeminiPromptFeedback`                | `Uralstech.UGemini.Chat`                  | `Uralstech.UGemini.Models.Generation.Candidate`                           |
| `GeminiUsageMetadata`                 | `Uralstech.UGemini.Chat`                  | `Uralstech.UGemini.Models.Generation.Candidate`                           |
| `GeminiFinishReason`                  | `Uralstech.UGemini.Chat`                  | `Uralstech.UGemini.Models.Generation.Candidate`                           |
| `GeminiChatRequest`                   | `Uralstech.UGemini.Chat`                  | `Uralstech.UGemini.Models.Generation.Chat`                                |
| `GeminiChatResponse`                  | `Uralstech.UGemini.Chat`                  | `Uralstech.UGemini.Models.Generation.Chat`                                |
| `GeminiAnswerRequest`                 | `Uralstech.UGemini.Answer`                | `Uralstech.UGemini.Models.Generation.QuestionAnswering`                   |
| `GeminiAnswerResponse`                | `Uralstech.UGemini.Answer`                | `Uralstech.UGemini.Models.Generation.QuestionAnswering`                   |
| `GeminiAnswerStyle`                   | `Uralstech.UGemini.Answer`                | `Uralstech.UGemini.Models.Generation.QuestionAnswering`                   |
| `GeminiGroundingPassage`              | `Uralstech.UGemini.Answer`                | `Uralstech.UGemini.Models.Generation.QuestionAnswering.Grounding`         |
| `GeminiGroundingPassages`             | `Uralstech.UGemini.Answer`                | `Uralstech.UGemini.Models.Generation.QuestionAnswering.Grounding`         |
| `GeminiMetadataCondition`             | `Uralstech.UGemini.Answer`                | `Uralstech.UGemini.Models.Generation.QuestionAnswering.SemanticRetriever` |
| `GeminiMetadataFilter`                | `Uralstech.UGemini.Answer`                | `Uralstech.UGemini.Models.Generation.QuestionAnswering.SemanticRetriever` |
| `GeminiSemanticRetrieverConfig`       | `Uralstech.UGemini.Answer`                | `Uralstech.UGemini.Models.Generation.QuestionAnswering.SemanticRetriever` |
| `GeminiMetadataConditionOperator`     | `Uralstech.UGemini.Answer`                | `Uralstech.UGemini.Models.Generation.QuestionAnswering.SemanticRetriever` |
| `GeminiSafetyRating`                  | `Uralstech.UGemini.Chat`                  | `Uralstech.UGemini.Models.Generation.Safety`                              |
| `GeminiSafetySettings`                | `Uralstech.UGemini.Chat`                  | `Uralstech.UGemini.Models.Generation.Safety`                              |
| `GeminiBlockReason`                   | `Uralstech.UGemini.Chat`                  | `Uralstech.UGemini.Models.Generation.Safety`                              |
| `GeminiHarmProbability`               | `Uralstech.UGemini.Chat`                  | `Uralstech.UGemini.Models.Generation.Safety`                              |
| `GeminiSafetyHarmBlockThreshold`      | `Uralstech.UGemini.Chat`                  | `Uralstech.UGemini.Models.Generation.Safety`                              |
| `GeminiSafetyHarmCategory`            | `Uralstech.UGemini.Chat`                  | `Uralstech.UGemini.Models.Generation.Safety`                              |
| `GeminiSchema`                        | `Uralstech.UGemini.Schema`                | `Uralstech.UGemini.Models.Generation.Schema`                              |
| `GeminiSchemaDataFormat`              | `Uralstech.UGemini.Schema`                | `Uralstech.UGemini.Models.Generation.Schema`                              |
| `GeminiSchemaDataType`                | `Uralstech.UGemini.Schema`                | `Uralstech.UGemini.Models.Generation.Schema`                              |
| `GeminiFunctionCall`                  | `Uralstech.UGemini.Tools`                 | `Uralstech.UGemini.Models.Generation.Tools`                               |
| `GeminiFunctionResponse`              | `Uralstech.UGemini.Tools`                 | `Uralstech.UGemini.Models.Generation.Tools`                               |
| `GeminiFunctionResponseContent`       | `Uralstech.UGemini.Tools`                 | `Uralstech.UGemini.Models.Generation.Tools`                               |
| `GeminiFunctionCallingConfiguration`  | `Uralstech.UGemini.Tools.Declaration`     | `Uralstech.UGemini.Models.Generation.Tools.Declaration`                   |
| `GeminiFunctionDeclaration`           | `Uralstech.UGemini.Tools.Declaration`     | `Uralstech.UGemini.Models.Generation.Tools.Declaration`                   |
| `GeminiTool`                          | `Uralstech.UGemini.Tools.Declaration`     | `Uralstech.UGemini.Models.Generation.Tools.Declaration`                   |
| `GeminiToolConfiguration`             | `Uralstech.UGemini.Tools.Declaration`     | `Uralstech.UGemini.Models.Generation.Tools.Declaration`                   |
| `GeminiFunctionCallingMode`           | `Uralstech.UGemini.Tools.Declaration`     | `Uralstech.UGemini.Models.Generation.Tools.Declaration`                   |
|                                       |                                           |                                                                           |