using FluentAssertions;
using TaskPulse.Domain.Entities;
using TaskPulse.Domain.Enums;
using Xunit;

namespace TaskPulse.UnitTests;

public class TaskItemTests
{
    [Fact]
    public void Should_Create_TaskItem_With_Valid_Properties()
    {
        var task = new TaskItem("Primeiro teste", "Descrição do teste", TaskPriority.High, TaskState.Pending, Guid.NewGuid(), null);

        task.Title.Should().Be("Primeiro teste");
        task.Description.Should().Be("Descrição do teste");
        task.Priority.Should().Be(TaskPriority.High);
        task.State.Should().Be(TaskState.Pending);
    }
}