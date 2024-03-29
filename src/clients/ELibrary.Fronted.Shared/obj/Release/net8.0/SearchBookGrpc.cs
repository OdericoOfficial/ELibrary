// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: searchBook.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace ELibrary.Protos {
  public static partial class SearchBook
  {
    static readonly string __ServiceName = "elibrary.SearchBook";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ELibrary.Protos.GetBookOrderByTimeRequest> __Marshaller_elibrary_GetBookOrderByTimeRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ELibrary.Protos.GetBookOrderByTimeRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ELibrary.Protos.GetBookOrderByTimeResponse> __Marshaller_elibrary_GetBookOrderByTimeResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ELibrary.Protos.GetBookOrderByTimeResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ELibrary.Protos.GetBookOrderByScoreRequest> __Marshaller_elibrary_GetBookOrderByScoreRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ELibrary.Protos.GetBookOrderByScoreRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ELibrary.Protos.GetBookOrderByScoreResponse> __Marshaller_elibrary_GetBookOrderByScoreResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ELibrary.Protos.GetBookOrderByScoreResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ELibrary.Protos.GetBookOrderByPublishYearRequest> __Marshaller_elibrary_GetBookOrderByPublishYearRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ELibrary.Protos.GetBookOrderByPublishYearRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ELibrary.Protos.GetBookOrderByPublishYearResponse> __Marshaller_elibrary_GetBookOrderByPublishYearResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ELibrary.Protos.GetBookOrderByPublishYearResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ELibrary.Protos.GetBookOrderByTimeRequest, global::ELibrary.Protos.GetBookOrderByTimeResponse> __Method_GetBookOrderByTime = new grpc::Method<global::ELibrary.Protos.GetBookOrderByTimeRequest, global::ELibrary.Protos.GetBookOrderByTimeResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetBookOrderByTime",
        __Marshaller_elibrary_GetBookOrderByTimeRequest,
        __Marshaller_elibrary_GetBookOrderByTimeResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ELibrary.Protos.GetBookOrderByScoreRequest, global::ELibrary.Protos.GetBookOrderByScoreResponse> __Method_GetBookOrderByScore = new grpc::Method<global::ELibrary.Protos.GetBookOrderByScoreRequest, global::ELibrary.Protos.GetBookOrderByScoreResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetBookOrderByScore",
        __Marshaller_elibrary_GetBookOrderByScoreRequest,
        __Marshaller_elibrary_GetBookOrderByScoreResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ELibrary.Protos.GetBookOrderByPublishYearRequest, global::ELibrary.Protos.GetBookOrderByPublishYearResponse> __Method_GetBookOrderByPublishYear = new grpc::Method<global::ELibrary.Protos.GetBookOrderByPublishYearRequest, global::ELibrary.Protos.GetBookOrderByPublishYearResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetBookOrderByPublishYear",
        __Marshaller_elibrary_GetBookOrderByPublishYearRequest,
        __Marshaller_elibrary_GetBookOrderByPublishYearResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::ELibrary.Protos.SearchBookReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of SearchBook</summary>
    [grpc::BindServiceMethod(typeof(SearchBook), "BindService")]
    public abstract partial class SearchBookBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task GetBookOrderByTime(global::ELibrary.Protos.GetBookOrderByTimeRequest request, grpc::IServerStreamWriter<global::ELibrary.Protos.GetBookOrderByTimeResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task GetBookOrderByScore(global::ELibrary.Protos.GetBookOrderByScoreRequest request, grpc::IServerStreamWriter<global::ELibrary.Protos.GetBookOrderByScoreResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task GetBookOrderByPublishYear(global::ELibrary.Protos.GetBookOrderByPublishYearRequest request, grpc::IServerStreamWriter<global::ELibrary.Protos.GetBookOrderByPublishYearResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for SearchBook</summary>
    public partial class SearchBookClient : grpc::ClientBase<SearchBookClient>
    {
      /// <summary>Creates a new client for SearchBook</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public SearchBookClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for SearchBook that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public SearchBookClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected SearchBookClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected SearchBookClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::ELibrary.Protos.GetBookOrderByTimeResponse> GetBookOrderByTime(global::ELibrary.Protos.GetBookOrderByTimeRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetBookOrderByTime(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::ELibrary.Protos.GetBookOrderByTimeResponse> GetBookOrderByTime(global::ELibrary.Protos.GetBookOrderByTimeRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_GetBookOrderByTime, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::ELibrary.Protos.GetBookOrderByScoreResponse> GetBookOrderByScore(global::ELibrary.Protos.GetBookOrderByScoreRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetBookOrderByScore(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::ELibrary.Protos.GetBookOrderByScoreResponse> GetBookOrderByScore(global::ELibrary.Protos.GetBookOrderByScoreRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_GetBookOrderByScore, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::ELibrary.Protos.GetBookOrderByPublishYearResponse> GetBookOrderByPublishYear(global::ELibrary.Protos.GetBookOrderByPublishYearRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetBookOrderByPublishYear(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::ELibrary.Protos.GetBookOrderByPublishYearResponse> GetBookOrderByPublishYear(global::ELibrary.Protos.GetBookOrderByPublishYearRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_GetBookOrderByPublishYear, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override SearchBookClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new SearchBookClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(SearchBookBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetBookOrderByTime, serviceImpl.GetBookOrderByTime)
          .AddMethod(__Method_GetBookOrderByScore, serviceImpl.GetBookOrderByScore)
          .AddMethod(__Method_GetBookOrderByPublishYear, serviceImpl.GetBookOrderByPublishYear).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, SearchBookBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetBookOrderByTime, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::ELibrary.Protos.GetBookOrderByTimeRequest, global::ELibrary.Protos.GetBookOrderByTimeResponse>(serviceImpl.GetBookOrderByTime));
      serviceBinder.AddMethod(__Method_GetBookOrderByScore, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::ELibrary.Protos.GetBookOrderByScoreRequest, global::ELibrary.Protos.GetBookOrderByScoreResponse>(serviceImpl.GetBookOrderByScore));
      serviceBinder.AddMethod(__Method_GetBookOrderByPublishYear, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::ELibrary.Protos.GetBookOrderByPublishYearRequest, global::ELibrary.Protos.GetBookOrderByPublishYearResponse>(serviceImpl.GetBookOrderByPublishYear));
    }

  }
}
#endregion
