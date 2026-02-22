using MediatR;

namespace Softela.PestManagement.Application.Queries.FeatureFlag.GetFeatures;

public sealed record GetFeaturesRequest : IRequest<GetFeaturesResponse>;
