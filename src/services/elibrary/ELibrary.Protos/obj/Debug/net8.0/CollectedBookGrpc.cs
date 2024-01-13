// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: collectedBook.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace ELibrary.Protos {
  public static partial class CollectedBook
  {
    static readonly string __ServiceName = "elibrary.CollectedBook";

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
    static readonly grpc::Marshaller<global::ELibrary.Protos.UploadCollectedRequest> __Marshaller_elibrary_UploadCollectedRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ELibrary.Protos.UploadCollectedRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Protobuf.WellKnownTypes.Empty.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ELibrary.Protos.DeleteCollectedRequest> __Marshaller_elibrary_DeleteCollectedRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ELibrary.Protos.DeleteCollectedRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ELibrary.Protos.GetCollectedBookRequest> __Marshaller_elibrary_GetCollectedBookRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ELibrary.Protos.GetCollectedBookRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ELibrary.Protos.GetCollectedBookResponse> __Marshaller_elibrary_GetCollectedBookResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ELibrary.Protos.GetCollectedBookResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ELibrary.Protos.IsCollectedRequest> __Marshaller_elibrary_IsCollectedRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ELibrary.Protos.IsCollectedRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ELibrary.Protos.IsCollectedResponse> __Marshaller_elibrary_IsCollectedResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ELibrary.Protos.IsCollectedResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ELibrary.Protos.UploadCollectedRequest, global::Google.Protobuf.WellKnownTypes.Empty> __Method_UploadCollected = new grpc::Method<global::ELibrary.Protos.UploadCollectedRequest, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UploadCollected",
        __Marshaller_elibrary_UploadCollectedRequest,
        __Marshaller_google_protobuf_Empty);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ELibrary.Protos.DeleteCollectedRequest, global::Google.Protobuf.WellKnownTypes.Empty> __Method_DeleteCollected = new grpc::Method<global::ELibrary.Protos.DeleteCollectedRequest, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteCollected",
        __Marshaller_elibrary_DeleteCollectedRequest,
        __Marshaller_google_protobuf_Empty);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ELibrary.Protos.GetCollectedBookRequest, global::ELibrary.Protos.GetCollectedBookResponse> __Method_GetCollectedBook = new grpc::Method<global::ELibrary.Protos.GetCollectedBookRequest, global::ELibrary.Protos.GetCollectedBookResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetCollectedBook",
        __Marshaller_elibrary_GetCollectedBookRequest,
        __Marshaller_elibrary_GetCollectedBookResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ELibrary.Protos.IsCollectedRequest, global::ELibrary.Protos.IsCollectedResponse> __Method_IsCollected = new grpc::Method<global::ELibrary.Protos.IsCollectedRequest, global::ELibrary.Protos.IsCollectedResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "IsCollected",
        __Marshaller_elibrary_IsCollectedRequest,
        __Marshaller_elibrary_IsCollectedResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::ELibrary.Protos.CollectedBookReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of CollectedBook</summary>
    [grpc::BindServiceMethod(typeof(CollectedBook), "BindService")]
    public abstract partial class CollectedBookBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> UploadCollected(global::ELibrary.Protos.UploadCollectedRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> DeleteCollected(global::ELibrary.Protos.DeleteCollectedRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task GetCollectedBook(global::ELibrary.Protos.GetCollectedBookRequest request, grpc::IServerStreamWriter<global::ELibrary.Protos.GetCollectedBookResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ELibrary.Protos.IsCollectedResponse> IsCollected(global::ELibrary.Protos.IsCollectedRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for CollectedBook</summary>
    public partial class CollectedBookClient : grpc::ClientBase<CollectedBookClient>
    {
      /// <summary>Creates a new client for CollectedBook</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public CollectedBookClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for CollectedBook that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public CollectedBookClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected CollectedBookClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected CollectedBookClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty UploadCollected(global::ELibrary.Protos.UploadCollectedRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UploadCollected(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty UploadCollected(global::ELibrary.Protos.UploadCollectedRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_UploadCollected, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> UploadCollectedAsync(global::ELibrary.Protos.UploadCollectedRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UploadCollectedAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> UploadCollectedAsync(global::ELibrary.Protos.UploadCollectedRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_UploadCollected, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty DeleteCollected(global::ELibrary.Protos.DeleteCollectedRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteCollected(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty DeleteCollected(global::ELibrary.Protos.DeleteCollectedRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_DeleteCollected, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> DeleteCollectedAsync(global::ELibrary.Protos.DeleteCollectedRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteCollectedAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> DeleteCollectedAsync(global::ELibrary.Protos.DeleteCollectedRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_DeleteCollected, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::ELibrary.Protos.GetCollectedBookResponse> GetCollectedBook(global::ELibrary.Protos.GetCollectedBookRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetCollectedBook(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::ELibrary.Protos.GetCollectedBookResponse> GetCollectedBook(global::ELibrary.Protos.GetCollectedBookRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_GetCollectedBook, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::ELibrary.Protos.IsCollectedResponse IsCollected(global::ELibrary.Protos.IsCollectedRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return IsCollected(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::ELibrary.Protos.IsCollectedResponse IsCollected(global::ELibrary.Protos.IsCollectedRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_IsCollected, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::ELibrary.Protos.IsCollectedResponse> IsCollectedAsync(global::ELibrary.Protos.IsCollectedRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return IsCollectedAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::ELibrary.Protos.IsCollectedResponse> IsCollectedAsync(global::ELibrary.Protos.IsCollectedRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_IsCollected, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override CollectedBookClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new CollectedBookClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(CollectedBookBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_UploadCollected, serviceImpl.UploadCollected)
          .AddMethod(__Method_DeleteCollected, serviceImpl.DeleteCollected)
          .AddMethod(__Method_GetCollectedBook, serviceImpl.GetCollectedBook)
          .AddMethod(__Method_IsCollected, serviceImpl.IsCollected).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, CollectedBookBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_UploadCollected, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ELibrary.Protos.UploadCollectedRequest, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.UploadCollected));
      serviceBinder.AddMethod(__Method_DeleteCollected, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ELibrary.Protos.DeleteCollectedRequest, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.DeleteCollected));
      serviceBinder.AddMethod(__Method_GetCollectedBook, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::ELibrary.Protos.GetCollectedBookRequest, global::ELibrary.Protos.GetCollectedBookResponse>(serviceImpl.GetCollectedBook));
      serviceBinder.AddMethod(__Method_IsCollected, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ELibrary.Protos.IsCollectedRequest, global::ELibrary.Protos.IsCollectedResponse>(serviceImpl.IsCollected));
    }

  }
}
#endregion
