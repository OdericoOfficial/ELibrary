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
    static readonly grpc::Marshaller<global::ELibrary.Protos.GetBookRequest> __Marshaller_elibrary_GetBookRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ELibrary.Protos.GetBookRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ELibrary.Protos.GetBookResponse> __Marshaller_elibrary_GetBookResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ELibrary.Protos.GetBookResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ELibrary.Protos.GetBookByUserRequest> __Marshaller_elibrary_GetBookByUserRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ELibrary.Protos.GetBookByUserRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ELibrary.Protos.GetBookDetailRequest> __Marshaller_elibrary_GetBookDetailRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ELibrary.Protos.GetBookDetailRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ELibrary.Protos.GetBookDetailResponse> __Marshaller_elibrary_GetBookDetailResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ELibrary.Protos.GetBookDetailResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ELibrary.Protos.GetBookRequest, global::ELibrary.Protos.GetBookResponse> __Method_GetBookOrderByTime = new grpc::Method<global::ELibrary.Protos.GetBookRequest, global::ELibrary.Protos.GetBookResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetBookOrderByTime",
        __Marshaller_elibrary_GetBookRequest,
        __Marshaller_elibrary_GetBookResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ELibrary.Protos.GetBookRequest, global::ELibrary.Protos.GetBookResponse> __Method_GetBookOrderByScore = new grpc::Method<global::ELibrary.Protos.GetBookRequest, global::ELibrary.Protos.GetBookResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetBookOrderByScore",
        __Marshaller_elibrary_GetBookRequest,
        __Marshaller_elibrary_GetBookResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ELibrary.Protos.GetBookRequest, global::ELibrary.Protos.GetBookResponse> __Method_GetBookOrderByPublishYear = new grpc::Method<global::ELibrary.Protos.GetBookRequest, global::ELibrary.Protos.GetBookResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetBookOrderByPublishYear",
        __Marshaller_elibrary_GetBookRequest,
        __Marshaller_elibrary_GetBookResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ELibrary.Protos.GetBookByUserRequest, global::ELibrary.Protos.GetBookResponse> __Method_GetBookOrderByUser = new grpc::Method<global::ELibrary.Protos.GetBookByUserRequest, global::ELibrary.Protos.GetBookResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetBookOrderByUser",
        __Marshaller_elibrary_GetBookByUserRequest,
        __Marshaller_elibrary_GetBookResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ELibrary.Protos.GetBookDetailRequest, global::ELibrary.Protos.GetBookDetailResponse> __Method_GetBookDetail = new grpc::Method<global::ELibrary.Protos.GetBookDetailRequest, global::ELibrary.Protos.GetBookDetailResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetBookDetail",
        __Marshaller_elibrary_GetBookDetailRequest,
        __Marshaller_elibrary_GetBookDetailResponse);

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
      public virtual global::System.Threading.Tasks.Task GetBookOrderByTime(global::ELibrary.Protos.GetBookRequest request, grpc::IServerStreamWriter<global::ELibrary.Protos.GetBookResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task GetBookOrderByScore(global::ELibrary.Protos.GetBookRequest request, grpc::IServerStreamWriter<global::ELibrary.Protos.GetBookResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task GetBookOrderByPublishYear(global::ELibrary.Protos.GetBookRequest request, grpc::IServerStreamWriter<global::ELibrary.Protos.GetBookResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task GetBookOrderByUser(global::ELibrary.Protos.GetBookByUserRequest request, grpc::IServerStreamWriter<global::ELibrary.Protos.GetBookResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ELibrary.Protos.GetBookDetailResponse> GetBookDetail(global::ELibrary.Protos.GetBookDetailRequest request, grpc::ServerCallContext context)
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
      public virtual grpc::AsyncServerStreamingCall<global::ELibrary.Protos.GetBookResponse> GetBookOrderByTime(global::ELibrary.Protos.GetBookRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetBookOrderByTime(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::ELibrary.Protos.GetBookResponse> GetBookOrderByTime(global::ELibrary.Protos.GetBookRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_GetBookOrderByTime, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::ELibrary.Protos.GetBookResponse> GetBookOrderByScore(global::ELibrary.Protos.GetBookRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetBookOrderByScore(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::ELibrary.Protos.GetBookResponse> GetBookOrderByScore(global::ELibrary.Protos.GetBookRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_GetBookOrderByScore, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::ELibrary.Protos.GetBookResponse> GetBookOrderByPublishYear(global::ELibrary.Protos.GetBookRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetBookOrderByPublishYear(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::ELibrary.Protos.GetBookResponse> GetBookOrderByPublishYear(global::ELibrary.Protos.GetBookRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_GetBookOrderByPublishYear, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::ELibrary.Protos.GetBookResponse> GetBookOrderByUser(global::ELibrary.Protos.GetBookByUserRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetBookOrderByUser(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::ELibrary.Protos.GetBookResponse> GetBookOrderByUser(global::ELibrary.Protos.GetBookByUserRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_GetBookOrderByUser, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::ELibrary.Protos.GetBookDetailResponse GetBookDetail(global::ELibrary.Protos.GetBookDetailRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetBookDetail(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::ELibrary.Protos.GetBookDetailResponse GetBookDetail(global::ELibrary.Protos.GetBookDetailRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetBookDetail, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::ELibrary.Protos.GetBookDetailResponse> GetBookDetailAsync(global::ELibrary.Protos.GetBookDetailRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetBookDetailAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::ELibrary.Protos.GetBookDetailResponse> GetBookDetailAsync(global::ELibrary.Protos.GetBookDetailRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetBookDetail, null, options, request);
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
          .AddMethod(__Method_GetBookOrderByPublishYear, serviceImpl.GetBookOrderByPublishYear)
          .AddMethod(__Method_GetBookOrderByUser, serviceImpl.GetBookOrderByUser)
          .AddMethod(__Method_GetBookDetail, serviceImpl.GetBookDetail).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, SearchBookBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetBookOrderByTime, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::ELibrary.Protos.GetBookRequest, global::ELibrary.Protos.GetBookResponse>(serviceImpl.GetBookOrderByTime));
      serviceBinder.AddMethod(__Method_GetBookOrderByScore, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::ELibrary.Protos.GetBookRequest, global::ELibrary.Protos.GetBookResponse>(serviceImpl.GetBookOrderByScore));
      serviceBinder.AddMethod(__Method_GetBookOrderByPublishYear, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::ELibrary.Protos.GetBookRequest, global::ELibrary.Protos.GetBookResponse>(serviceImpl.GetBookOrderByPublishYear));
      serviceBinder.AddMethod(__Method_GetBookOrderByUser, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::ELibrary.Protos.GetBookByUserRequest, global::ELibrary.Protos.GetBookResponse>(serviceImpl.GetBookOrderByUser));
      serviceBinder.AddMethod(__Method_GetBookDetail, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ELibrary.Protos.GetBookDetailRequest, global::ELibrary.Protos.GetBookDetailResponse>(serviceImpl.GetBookDetail));
    }

  }
}
#endregion