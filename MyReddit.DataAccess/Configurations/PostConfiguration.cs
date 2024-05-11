using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyReddit.Core.Models;
using MyReddit.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReddit.DataAccess.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<PostEntity>
    {
        public void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
                .HasMaxLength(Post.max_title_length)
                .IsRequired();
            builder.Property(x => x.Content)
                .IsRequired();
            builder.HasOne(x => x.UserEntity);
            builder.HasOne(x => x.TopicEntity);
        }
    }
}
