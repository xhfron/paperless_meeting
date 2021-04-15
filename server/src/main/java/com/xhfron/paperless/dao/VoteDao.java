package com.xhfron.paperless.dao;

import com.xhfron.paperless.bean.Option;
import com.xhfron.paperless.bean.Vote;
import org.apache.ibatis.annotations.Insert;
import org.apache.ibatis.annotations.MapKey;
import org.apache.ibatis.annotations.Mapper;

@Mapper
public interface VoteDao {
    int createVote(Vote vote);
    int addOption(Option option);
}
